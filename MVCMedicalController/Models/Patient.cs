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
        [Display(Name = "Second Name")]
        [Column("PatientSoName")]
        public string PatientSoName { get; set; } = "Иванов";

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [Column("PatientName")]
        public string? PatientName { get; set; } = "Иван";

        [Required]
        [StringLength(50)]
        [Display(Name = "Father Name")]
        [Column("PatientFatherName")]
        public string? PatientFatherName { get; set; } = "Иванович";

        [Required]
        [StringLength(300)]
        [Display(Name = "Adress")]
        [Column("SpecialityName")]
        public string? Adress { get; set; } = "Адрес";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Пол")]
        [Column("Sex")]
        public string? Sex { get; set; } = "муж";


        [ForeignKey("sectorID")]
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
