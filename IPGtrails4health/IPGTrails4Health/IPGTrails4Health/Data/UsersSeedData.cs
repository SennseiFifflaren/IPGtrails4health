using IPGTrails4Health.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager)
        {
            const string adminEmail = "admin@admin.com";
            const string adminPassword = "Secret123$";
            ApplicationUser user = await userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                user = new ApplicationUser() { UserEmail = adminEmail };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
