using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Models
{
    public class Event
    {
        [Key]
        public string Id_event { get; set; }
        public string Id_angkatan { get; set; }
        [Required]
        public string Nama_event { get; set; }
        [Required]
        public DateTime Tanggal { get; set; }
        [Required]
        public string Tempat { get; set; }
        [Required]
        public string Waktu { get; set; }
        [Required]
        public DateTime Batas_daftar { get; set; }
        [Required]
        public string Keterangan { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("Id_angkatan")]
        public Tahun Nama_angkatan { get; set; }
    }
}
