using Microsoft.AspNetCore.Identity;
using Mo3aqin.Constane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }
           
        }
    }
}
