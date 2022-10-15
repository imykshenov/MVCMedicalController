using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCMedicalController.Data;
using System;
using System.Linq;

namespace MVCMedicalController.Models.SeedData
{
    public static class SeedSectorsData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCMedicalControllerContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<MVCMedicalControllerContext>>()))
            {
                // Look for any movies.
                if (context.Sector.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sector.AddRange(
                    new Sector
                    {
                        Title = "Участок 1"
                    },

                    new Sector
                    {
                        Title = "Участок 2"
                    },

                    new Sector
                    {
                        Title = "Участок 3"
                    },

                    new Sector
                    {
                        Title = "Участок 4"

                    },

                    new Sector
                    {
                        Title = "Участок 5"
                    },

                    new Sector
                    {
                        Title = "Участок 6"
                    },

                    new Sector
                    {
                        Title = "Участок 7"
                    },

                    new Sector
                    {
                        Title = "Участок 8"

                    }


                );
                context.SaveChanges();
            }
        }
    }
   
}
