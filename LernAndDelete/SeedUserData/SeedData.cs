using LernAndDelete.Data;
using LernAndDelete.Models;
using Microsoft.AspNetCore.Identity;

namespace LernAndDelete.SeedUserData
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            // Check if roles exist, if not, create them
            string[] roleNames = { "Admin", "User", "Manager" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Check if a user already exists
            var user = await userManager.FindByEmailAsync("admin@example.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    FirstName="Admin",
                };

                var result = await userManager.CreateAsync(user, "Admin@123");

                if (result.Succeeded)
                {
                    // Assign Admin role to the user
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            user = await userManager.FindByEmailAsync("user@example.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "user@example.com",
                    Email = "user@example.com",
                    FirstName = "User",
                };

                var result = await userManager.CreateAsync(user, "User@123");

                if (result.Succeeded)
                {
                    // Assign User role to the user
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

            // Add additional seeding logic for other entities here if needed
        }
    }

}
