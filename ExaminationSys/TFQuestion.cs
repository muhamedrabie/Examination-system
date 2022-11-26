using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class TFQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TfqId { get; set; }
        [MaxLength(200), Required]
        public string TfqContent { get; set; }
        [MaxLength(5), Required]
        public string TfqCorrectAnswer { get; set; }
        public int TfqFullDegree { get; set; }
        [ForeignKey("Course")]
        public int? CrsId { get; set; }

        public virtual Course Course { get; set; }
    }
}
