using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class Instructor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        [MaxLength(50), Required]
        public string InsName { get; set; }
        [MaxLength(50), Required]
        public string InsUserName { get; set; }
        [Required]
        public string InsPassword { get; set; }
        [Required]
        public int SuperID { get; set; }

        [ForeignKey(nameof(SuperID))]
        public virtual Instructor instructor { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<Course> Courses { get; set; }
        public virtual User User { get; set; }
    }
}
