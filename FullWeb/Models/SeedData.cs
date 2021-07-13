using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FullWeb.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Project.Any())
                {
                    return; //DB seeded
                }

                context.Project.AddRange(
                    new Project
                    {
                        ProjectName = "Career Talks"
                    },

                    new Project
                    {
                        ProjectName = "Feeding Scheme"
                    },

                    new Project
                    {
                        ProjectName = "Clothing"
                    },

                    new Project
                    {
                        ProjectName = "Fundraising"
                    },

                    new Project
                    {
                        ProjectName = "Food Packs"
                    });

                context.SaveChanges();
            }
            
        }
    }
}
