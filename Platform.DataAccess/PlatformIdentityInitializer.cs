using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess
{
    public class PlatformIdentityInitializer
    {
        private RoleManager<IdentityRole> _roleMgr;
        private UserManager<User> _userMgr;

        public PlatformIdentityInitializer(UserManager<User> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
        }

        public async Task Seed()
        {
            var user = await _userMgr.FindByNameAsync("Admin");

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
                    FirstName = "Admin",
                    LastName = "Adminovich",
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
        }
    }
}
