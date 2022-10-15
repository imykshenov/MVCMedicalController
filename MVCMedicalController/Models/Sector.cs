using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCMedicalController.Models
{
    public class Sector
    {
        [Key] public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Номер участка")]
        public string Title { get; set; } = "Участок 1";

    }
}