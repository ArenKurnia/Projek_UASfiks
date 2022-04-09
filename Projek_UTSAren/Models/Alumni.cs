using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Models
{
    public class Alumni
    {
        [Key]
        public string NIM { get; set; }
        [Required]
        public string Nama_alumni { get; set; }
        [Required]
        public int Tahun_angkatan { get; set; }
        [Required]
        public string Jenis_kelamin { get; set; }
        [Required]
        public string Tempat_lahir { get; set; }
        [Required]
        public DateTime Tanggal_lahir { get; set; }
        [Required]
        public string Pekerjaan { get; set; }
        [Required]
        public string Alamat { get; set; }
        [Required]
        public string Telp { get; set; }
        public string Foto { get; set; }
        public Roles Roles { get; set; }
    }

}
