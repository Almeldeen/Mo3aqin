using Microsoft.AspNetCore.Identity;
using Mo3aqin.Constane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mo3aqin.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultuser = new IdentityUser()
            {
                UserName = "SuperAdmin",
                Email = "SuperAdmin@g.com",
                EmailConfirmed = true
            };
           var user=await userManager.FindByEmailAsync(defaultuser.Email);
            if (user ==null)
            {
               await userManager.CreateAsync(defaultuser, "SuperAdmin@123");
                await userManager.AddToRolesAsync(defaultuser, new List<string> {Roles.SuperAdmin.ToString(),Roles.Admin.ToString(),Roles.User.ToString() } );
            }
            await roleManager.SeedClaimsForSuperAdmin();
        }
        public static async Task SeedsAdminUsersAsync(UserManager<IdentityUser> userManager)
        {
            var defaultuser = new IdentityUser()
            {
                UserName = "Admin",
                Email = "Admin@g.com",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defaultuser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultuser, "Admin@123");
                await userManager.AddToRolesAsync(defaultuser, new List<string> {Roles.Admin.ToString(), Roles.User.ToString() });
            }
        }
        public static async Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var superAdminRoles = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            await roleManager.AddPermissionClaims(superAdminRoles, Modules.Players.ToString());
        }
        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allclaims = await roleManager.GetClaimsAsync(role);
            var allPermission = Permissions.GeneratePermissionsList(module);
            foreach (var Permission in allPermission)
            {
                if (!allclaims.Any(c => c.Type == "Permission" && c.Value == Permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", Permission));
            }

        }
    }
}
