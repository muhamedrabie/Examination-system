using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class Track
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }
        [MaxLength(50), Required]
        public String TrackName { get; set; }
    }
}
