using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class StdAnswers
    {
        [Key, Column(Order = 0), Required, ForeignKey("Student")]
        public int StdId { get; set; }
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QstId { get; set; }
        [Key, Column(Order = 2), Required, MaxLength(3)]
        public string QstType { get; set; }
        [MaxLength(200)]
        public string StdAnswer { get; set; }
        [Required]
        public int ExamId { get; set; }
        [DefaultValue(0)]
        public int StdDegree { get; set; }
        public DateTime Time { get; set; }

        public virtual Student Student { get; set; }
    }
}
