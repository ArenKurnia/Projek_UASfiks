using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nama_Lengkap { get; set; }
        [Required]
        public string Email { get; set; }
        public Roles Roles { get; set; }

    }
}
