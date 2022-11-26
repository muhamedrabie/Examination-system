using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSys
{
    internal class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }
        [Required, Index(IsUnique = true), MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public UserType UserType { get; set; }

        public void AssignRole(UserType role)
        {
            UserType |= role;
        }

        public bool HasRole(UserType role)
        {
            return (UserType & role) == role;
        }
    }
}
