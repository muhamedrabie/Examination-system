using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class MCQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int McqId { get; set; }
        [Required]
        public char McqCorrectChoice { get; set; }
        [MaxLength(200), Required]
        public string McqContent { get; set; }
        [MaxLength(150), Required]
        public string Choice1 { get; set; }
        [MaxLength(150), Required]
        public string Choice2 { get; set; }
        [MaxLength(150), Required]
        public string Choice3 { get; set; }
        [Required]
        public int McqFullDegree { get; set; }
        [ForeignKey("Course")]
        public int? CrsId { get; set; }

        public virtual Course Course { get; set; }
    }
}
