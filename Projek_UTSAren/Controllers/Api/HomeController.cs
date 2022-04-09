using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Helper;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.AlumniService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // service
        private readonly IAlumniService _alumniService;

        // class
        private BanyakBantuan _bantu = new();

        // tampungan objek
        private object _respon;
        private object _objek;

        // tampungan model
        private Alumni _TAlumni;
        // tampungan string
        private string SAlumni = "Alumni";
        private string SUser = "User";

        public HomeController(IAlumniService s)
        {
            _alumniService = s;
        }

        [Route("alumni")]
        public IActionResult Alumni()
        {
            _objek = _alumniService.AmbilSemuaAlumni();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SAlumni), _objek);
            return Ok(_respon);
        }

        [Route("alumni")]
        [HttpPost]
        public IActionResult CreateAlumni(Alumni alumni, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _alumniService.CreateAlumni(alumni, Image);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanTambahSukses(SAlumni), alumni);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SAlumni), null);
            return Ok(_respon);
        }

        [Route("alumni")]
        [HttpPut]
        public IActionResult UpdateAlumni(Alumni alumni, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _TAlumni = _alumniService.AmbilAlumniBerdasarkanId(alumni.NIM);
                if (_TAlumni != null)
                {
                    _alumniService.UpdateAlumni(alumni, Image);

                    _TAlumni = _alumniService.AmbilAlumniBerdasarkanId(alumni.NIM);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanUbahSukses(SAlumni), _TAlumni);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SAlumni), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SAlumni), null);
            return Ok(_respon);
        }

        [Route("alumni/{id}")]
        [HttpDelete]
        public IActionResult DeleteAlumni(string id)
        {
            try
            {
                _TAlumni = _alumniService.AmbilAlumniBerdasarkanId(id);

                if (_TAlumni != null)
                {
                    _alumniService.HapusAlumni(id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanHapusSukses(SAlumni), _TAlumni);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SAlumni), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SAlumni), null);
                return Ok(_respon);
            }
        }

        [Route("alumni/{id}")]
        public IActionResult Detail(string id)
        {
            _TAlumni = _alumniService.AmbilAlumniBerdasarkanId(id);

            if (_TAlumni != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SAlumni), _TAlumni);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SAlumni), null);
            return Ok(_respon);
        }
    }
}
