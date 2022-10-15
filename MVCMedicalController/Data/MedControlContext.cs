using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Models;

namespace MVCMedicalController.Data
{
    public class MedControlContext : DbContext
    {
        public MedControlContext (DbContextOptions<MedControlContext> options)
            : base(options)
        {
        }

        public DbSet<Sector> Sector { get; set; } = default!;

        public DbSet<Cabinet> Cabinet { get; set; }

        public DbSet<Speciality> Speciality { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().ToTable("Sector");
            modelBuilder.Entity<Cabinet>().ToTable("Cabinet");
            modelBuilder.Entity<Speciality>().ToTable("Speciality");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
        }


    }
}
