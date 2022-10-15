using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Models;

namespace MVCMedicalController.Data
{
    public class MVCMedicalControllerContext : DbContext
    {
        public MVCMedicalControllerContext (DbContextOptions<MVCMedicalControllerContext> options)
            : base(options)
        {
        }

        public DbSet<MVCMedicalController.Models.Sector> Sector { get; set; } = default!;

        public DbSet<MVCMedicalController.Models.Cabinet> Cabinet { get; set; }

        public DbSet<MVCMedicalController.Models.Speciality> Speciality { get; set; }
    }
}
