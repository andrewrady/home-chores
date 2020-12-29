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
                if(context.Chore.Any())
                {
                    return;
                }

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
                context.SaveChanges();
            }
                    
        }
    }
}