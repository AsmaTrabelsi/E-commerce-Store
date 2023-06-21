using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "admin",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    Address = new Adddress
                    {
                        FirstName = "admin",
                        LastName = "Admin",
                        Street = "10 the street",
                        City = "new york",
                        State = "NY",
                        zipCode = "89065"
                    }
                };

                await userManager.CreateAsync(user,"Pa$$0test123!");
            }
        }
    }
}
