using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Models;


namespace MVCMedicalController.Data
{
    public class MedicalContextDB : DbContext
    {
        public MedicalContextDB(DbContextOptions<MedicalContextDB> options) : base(options)
        {
        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Speciality> Specialties { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().ToTable("Sectors");
            modelBuilder.Entity<Speciality>().ToTable("Specialties");
            modelBuilder.Entity<Cabinet>().ToTable("Cabinets");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
        }

    }
}
