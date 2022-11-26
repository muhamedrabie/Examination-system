using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class TxtQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TxtId { get; set; }
        [MaxLength(200), Required]
        public string TxtContent { get; set; }
        [MaxLength(200), Required]
        public string TxtBestAnswer { get; set; }
        public int TxtFullDegree { get; set; }
        [ForeignKey("Course")]
        public int? CrsId { get; set; }

        public virtual Course Course { get; set; }
    }
}
