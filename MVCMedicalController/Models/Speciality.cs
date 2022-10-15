using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCMedicalController.Models
{
    public class Speciality
    {
        [Key]
        public int SpecialityID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Speciality")]
        public string? SpecialityName { get; set; }  = "Терапевт";
    }
}