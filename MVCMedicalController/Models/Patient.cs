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
        public string PatientSoName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string PatientName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Father Name")]
        public string PatientFatherName { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Adress")]
        public string Adress { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Father Name")]
        public string Sex { get; set; }

        [Key]
        [ForeignKey("SectorModel")]
        public int Sector { get; set; }

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
