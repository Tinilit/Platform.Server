using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess
{
    public class PlatformIdentityInitializer
    {
        private RoleManager<IdentityRole> _roleMgr;
        private UserManager<User> _userMgr;
        private IUnitOfWork _unitOfwork;

        public PlatformIdentityInitializer(UserManager<User> userMgr, RoleManager<IdentityRole> roleMgr, IUnitOfWork unitOfWork)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
            _unitOfwork = unitOfWork;
        }

        public async Task Seed()
        {
            var user = await _userMgr.FindByNameAsync("Admin");
            var user1 = await _userMgr.FindByNameAsync("User");

            // Add User
            if (user == null)
            {
                if (!(await _roleMgr.RoleExistsAsync("Admin")))
                {
                    var role1 = new IdentityRole("Admin");
                    var role2 = new IdentityRole("User");
                    var role3 = new IdentityRole("Provider");
                    role1.Claims.Add(new IdentityRoleClaim<string>() { ClaimType = "IsAdmin", ClaimValue = "True" });
                    await _roleMgr.CreateAsync(role1);
                    await _roleMgr.CreateAsync(role2);
                    await _roleMgr.CreateAsync(role3);
                }

                user = new User()
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com"
                };

                var userResult = await _userMgr.CreateAsync(user, "Admin");
                var roleResult = await _userMgr.AddToRoleAsync(user, "Admin");
                var claimResult = await _userMgr.AddClaimAsync(user, new Claim("SuperUser", "True"));
                
                if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }

            if (user1 == null)
            {
                if (!(await _roleMgr.RoleExistsAsync("Provider")))
                {
                    var role3 = new IdentityRole("Provider");
                    await _roleMgr.CreateAsync(role3);
                }

                user1 = new User()
                {
                    UserName = "Provider",
                    Email = "Provider@gmail.com"
                };

                var userResult1 = await _userMgr.CreateAsync(user1, "Provider");
                var roleResult1 = await _userMgr.AddToRoleAsync(user1, "User");
                var roleResult2 = await _userMgr.AddToRoleAsync(user1, "Provider");
                var claimResult1 = await _userMgr.AddClaimAsync(user1, new Claim("SuperUser", "True"));
            }
        }
    }
}
