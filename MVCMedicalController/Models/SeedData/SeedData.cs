using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMedicalController.Models.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCMedicalControllerContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<MVCMedicalControllerContext>>()))
            {
                // Look for any movies.
                //if (context.Cabinet.Any() || context.Sector.Any() || context.Speciality.Any())
                //{
                //    return;   // DB has been seeded
                //}

                for (var i = 1; i <= 5; i++)
                {
                    if (!context.Cabinet.Any())
                    {
                        context.Cabinet.Add(
                            new Cabinet
                            {
                                CabinetNumber = $"Кабинет {i}"
                            }

                        );
                    }

                    if (!context.Sector.Any())
                    {
                        context.Sector.Add(
                            new Sector
                            {
                                Title = $"Участок {i}"
                            }

                        );
                    }

                    if (!context.Speciality.Any())
                    {
                        context.Speciality.Add(
                            new Speciality
                            {
                                SpecialityName = $"Врач {i}"
                            }

                        );
                    }
                    
                }
                context.SaveChanges();
            }
        }
    }
}
