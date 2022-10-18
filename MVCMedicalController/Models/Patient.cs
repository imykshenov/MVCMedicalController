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
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        [Column("PatientSoName")]
        public string PatientSoName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Имя")]
        [Column("PatientName")]
        public string? PatientName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Отчество")]
        [Column("PatientFatherName")]
        public string PatientFatherName { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Адресс")]
        [Column("Adress")]
        public string Adress { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "День рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Пол")]
        [Column("Sex")]
        public string Sex { get; set; }


        [ForeignKey("sectorID")]
        [Display(Name = "Участок")]
        [Column("sectorID")]
        public int? sectorID { get; set; }

        public Sector? Sector { get; set; }



        [Required]
        [StringLength(150)]
        [Display(Name = "Full Name")]
        [Column("SpecialityName")]
        public string PatientFullName
        {
            get
            {
                return PatientSoName + " " + PatientName + " " + PatientFatherName;
            }
        }

    }
}
