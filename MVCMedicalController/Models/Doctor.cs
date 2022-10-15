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
        public string DoctorSoName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Father Name")]
        public string DoctorFatherName { get; set; }

        [Display(Name = "Full Name")]
        public string DoctorFullName
        {
            get
            {
                return DoctorSoName + " " + DoctorName + " " + DoctorFatherName;
            }
        }
        
        public ICollection<Cabinet> Cabinets{ get; set; }
        public ICollection<Speciality> Specialitys { get; set; }
        public ICollection<Sector> Sectors { get; set; }

       

    }
}