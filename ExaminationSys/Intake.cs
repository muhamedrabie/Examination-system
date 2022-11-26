using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class Intake
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntakeId { get; set; }
        [Required]
        public int IntakeNumber { get; set; }
    }
}
