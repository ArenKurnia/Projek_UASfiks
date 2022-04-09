using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Models
{
    public class Tahun
    {
        [Key]
        public string Id_angkatan { get; set; }
        [Required]
        public string Tahun_angkatan { get; set; }
        [Required]
        public string Nama_angkatan { get; set; }
    }
}
