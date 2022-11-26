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
    class Allowance
    {
        [Key, Required, ForeignKey("Exam")]
        public int ExamId { get; set; }
        [Required, Column(TypeName = "bit")]
        public bool Calculator { get; set; }
        [Required, Column(TypeName = "bit")]
        public bool OpenBook { get; set; }
        [Required, Column(TypeName = "bit")]
        public bool UseInternet { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
