using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StdId { get; set; }
        [MaxLength(50), Required]
        public string StdName { get; set; }
        [MaxLength(50), Required]
        public string StdEmail { get; set; }
        [MaxLength(50), Required]
        public string StdUserName { get; set; }
        [MaxLength(50), Required]
        public string StdPassword { get; set; }

        public virtual User User { get; set; }
    }
}
