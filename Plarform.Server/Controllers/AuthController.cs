using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Plarform.Server.Filters;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _hasher;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfigurationRoot _config;

        public AuthController(UserManager<User> userManager,
            IPasswordHasher<User> hasher,
            ILogger<AuthController> logger,
            IConfigurationRoot config)
        {
            _userManager = userManager;
            _hasher = hasher;
            _logger = logger;
            _config = config;
        }

        [HttpPost("token")]
        [ValidateModel]
        public async Task<IActionResult> CreateToken([FromBody] CredentialModel model)
        {
            try
            {
                User user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                    {
                        var userClaims = await _userManager.GetClaimsAsync(user);
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Email, user.Email??"undefined")
                        }.Union(userClaims);

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            issuer: _config["Tokens:Issuer"],
                            audience: _config["Tokens:Audience"],
                            claims: claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: creds);

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while creating JWT: {ex}");
                throw ex;
            }
            return BadRequest("Failed to generate token");
        }

        [HttpPost("register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] CredentialModel model)
        {
            if (model == null) return BadRequest();
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = model.UserName
                    };

                    var userResult = await _userManager.CreateAsync(user, model.Password);
                    if (!userResult.Succeeded) return BadRequest($"Error creating user: {userResult.Errors.Aggregate("", (current, error) => current + error.Description)}");

                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (!roleResult.Succeeded) return BadRequest($"Error adding user to role: {userResult.Errors.Aggregate("", (current, error) => current + error.Description)}");

                    return await CreateToken(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while registering user: {ex}");
                throw;
            }
            return BadRequest("Failed to register user");
        }
    }
}
