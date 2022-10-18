using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MVCMedicalController.Models
{
    public class Sector
    {
        [Key]
        public int SectorID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Номер участка")]
        [Column("SectorName")]
        public string SectorName { get; set; } = string.Empty;

    }
}