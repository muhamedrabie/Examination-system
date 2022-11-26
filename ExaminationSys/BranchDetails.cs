using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    class BranchDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, ForeignKey("Department")]
        public int DeptId { get; set; }
        [Required, ForeignKey("Intake")]
        public int IntakeId { get; set; }
        [Required, ForeignKey("Branch")]
        public int BranchId { get; set; }
        [Required, ForeignKey("Track")]
        public int TrackId { get; set; }
        [Required, ForeignKey("Course")]
        public int CrsId { get; set; }
        [Required, ForeignKey("Student")]
        public int StdId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Intake Intake { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Track Track { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
