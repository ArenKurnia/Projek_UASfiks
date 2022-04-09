using Microsoft.AspNetCore.Http;
using Projek_UTSAren.Models;
using Projek_UTSAren.Repositories.AlumniRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.AlumniService
{
    public class AlumniService : IAlumniService
    {
        private readonly IAlumniRepository _alumniRepository;
        private readonly FileService _file;

        public AlumniService(IAlumniRepository alumni, FileService f)
        {
            _alumniRepository = alumni;
            _file = f;
        }

        public Alumni AmbilAlumniBerdasarkanId(string id)
        {
            return _alumniRepository.AmbilAlumniBerdasarkanIdAsync(id).Result;
        }

        public List<Alumni> AmbilSemuaAlumni()
        {
            return _alumniRepository.AmbilSemuaAlumniAsync().Result;
        }

        public List<User> AmbilSemuaUser()
        {
            return _alumniRepository.AmbilSemuaUserAsync().Result;
        }

        public bool CreateAlumni(Alumni alumni, IFormFile Image)
        {
            alumni.Foto = _file.SimpanFile(Image).Result;
            return _alumniRepository.CreateAlumniAsync(alumni).Result;
        }

        public bool HapusAlumni(string id)
        {
            var cari = _alumniRepository.CariAlumniAsync(id).Result;
            return _alumniRepository.HapusAlumniAsync(cari).Result;
        }

        public bool UpdateAlumni(Alumni alumni, IFormFile Image)
        {
            var cari = _alumniRepository.CariAlumniAsync(alumni.NIM).Result;
            if(cari!= null)
            {
                cari.Nama_alumni = alumni.Nama_alumni;
                cari.Tahun_angkatan = alumni.Tahun_angkatan;
                cari.Jenis_kelamin = alumni.Jenis_kelamin;
                cari.Tempat_lahir = alumni.Tempat_lahir;
                cari.Tanggal_lahir = alumni.Tanggal_lahir;
                cari.Pekerjaan = alumni.Pekerjaan;
                cari.Alamat = alumni.Alamat;
                cari.Telp = alumni.Telp;

                if (Image != null) cari.Foto = _file.SimpanFile(Image).Result;
                else cari.Foto = cari.Foto;
                return _alumniRepository.UpdateAlumniAsync(cari).Result;
            }
            return false;
        }

    }
}
