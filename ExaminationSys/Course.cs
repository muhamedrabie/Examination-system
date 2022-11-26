using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrsId { get; set; }
        [MaxLength(50), Required]
        public string CrsTitle { get; set; }
        [MaxLength(200)]
        public string CrsDesc { get; set; }
        public int CrsMinDegree { get; set; }
        public int CrsMaxDegree { get; set; }
        [ForeignKey("Instructor")]
        public int InsId { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
