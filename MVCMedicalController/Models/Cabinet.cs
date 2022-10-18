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
    public class Cabinet
    {
        [Key]
        public int CabinetID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Номер кабинета")]
        [Column("CabinetNumber")]
        public string CabinetNumber { get; set; }
    }
}
