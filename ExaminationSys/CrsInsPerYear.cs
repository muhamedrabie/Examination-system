using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class CrsInsPerYear
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key, Column(Order = 0), ForeignKey("Class")]
        public int ClassId { get; set; }
        [Key, Column(Order = 1), ForeignKey("Course")]
        public int CrsId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Instructor")]
        public int InsId { get; set; }
        [Key, Column(Order = 3)]
        public int Year { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
    }
}
