using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace homeChores.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if(!context.Chore.Any())
                {
                    context.Chore.AddRange(
                        new Chore
                        {
                            Name = "Load Dishwasher",
                            Level = 3
                        },
                        new Chore
                        {
                            Name = "Unload Dishwasher",
                            Level = 2
                        },
                        new Chore
                        {
                            Name = "Clean Room",
                            Level = 1
                        }
                    );
                }

                if(!context.AppUsers.Any())
                {
                    var hasher = new PasswordHasher<AppUser>();

                    context.AppUsers.AddRange(
                        new AppUser
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = "test1@gmail.com",
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            PasswordHash = hasher.HashPassword(null, "Password1!")
                        },
                        new AppUser
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = "test2@gmail.com",
                            FirstName = "Clark",
                            LastName = "Kent",
                            PasswordHash = hasher.HashPassword(null, "Password1!")
                        }
                    );
                }

                context.SaveChanges();
            }
                    
        }
    }
}