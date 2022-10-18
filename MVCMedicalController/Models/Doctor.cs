using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCMedicalController.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Second Name")]
        [Column("DoctorSoName")]
        public string? DoctorSoName { get; set; } = "Иванов";

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [Column("DoctorName")]
        public string? DoctorName { get; set; } = "Иван";

        [Required]
        [StringLength(50)]
        [Display(Name = "Father Name")]
        [Column("DoctorFatherName")]
        public string? DoctorFatherName { get; set; } = "Иванович";

        [Required]
        [StringLength(150)]
        [Display(Name = "Full Name")]
        public string DoctorFullName
        {
            get
            {
                return DoctorSoName + " " + DoctorName + " " + DoctorFatherName;
            }
        }
        [ForeignKey("CabinetID")]
        [Column("CabinetID")]
        public int CabinetID { get; set; }
        public Cabinet? Cabinet{ get; set; }


        [ForeignKey("SpecialityID")]
        [Column("SpecialityID")]
        public int SpecialityID { get; set; }
        public Speciality? Speciality { get; set; }


        [ForeignKey("SectorID")]
        [Column("SectorID")]
        public int SectorID { get; set; }
        public Sector Sector { get; set; } 



    }
}