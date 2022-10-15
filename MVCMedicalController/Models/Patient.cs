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
        [StringLength(80)]
        [Display(Name = "Second Name")]
        public string PatientSoName { get; set; } = "Иванов";

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string? PatientName { get; set; } = "Иван";

        [Required]
        [StringLength(50)]
        [Display(Name = "Father Name")]
        public string? PatientFatherName { get; set; } = "Иванович";

        [Required]
        [StringLength(200)]
        [Display(Name = "Adress")]
        public string? Adress { get; set; } = "Адрес";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Father Name")]
        public string? Sex { get; set; } = "муж";

        public Sector? Sectors { get; set; }

        [Display(Name = "Full Name")]
        public string PatientFullName
        {
            get
            {
                return PatientSoName + " " + PatientName + " " + PatientFatherName;
            }
        }

    }
}
