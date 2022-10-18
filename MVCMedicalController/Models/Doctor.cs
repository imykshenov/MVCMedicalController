using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
        [Display(Name = "Фамилия")]
        [Column("DoctorSoName")]
        public string? DoctorSoName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Имя")]
        [Column("DoctorName")]
        public string? DoctorName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Отчество")]
        [Column("DoctorFatherName")]
        public string? DoctorFatherName { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "ФИО")]
        public string DoctorFullName
        {
            get
            {
                return DoctorSoName + " " + DoctorName + " " + DoctorFatherName;
            }
        }

        [Required]
        [Display(Name = "Кабинет")]
        [ForeignKey("CabinetID")]
        [Column("CabinetID")]
        public int CabinetID { get; set; }
        public Cabinet? Cabinet{ get; set; }

        [Required]
        [Display(Name = "Специальность")]
        [ForeignKey("SpecialityID")]
        [Column("SpecialityID")]
        public int SpecialityID { get; set; }
        public Speciality? Speciality { get; set; }

        [Required]
        [AllowNull]
        [Display(Name = "Участок")]
        [ForeignKey("SectorID")]
        [Column("SectorID")]
        public int? SectorID { get; set; }
        public Sector? Sector { get; set; } 



    }
}