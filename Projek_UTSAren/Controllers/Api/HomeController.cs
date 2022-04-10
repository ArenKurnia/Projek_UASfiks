using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Helper;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.AlumniService;
using Projek_UTSAren.Services.EventService;
using Projek_UTSAren.Services.TahunService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        //------------------------------ API UNTUK A L U M N I ---------------------------------------------------//
        // service
        private readonly IAlumniService _alumniService;
        private readonly IEventService _eventService;

        // class
        private BanyakBantuan _bantu = new();

        // tampungan objek
        private object _respon;
        private object _objek;

        // tampungan model
        private Alumni _TAlumni;
        // tampungan string
        private string SAlumni = "Alumni";

        public HomeController(IAlumniService a, IEventService e)
        {
            _alumniService = a;
            _eventService = e;
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

        //----------------------------------- API UNTUK EVENT ---------------------------------------------------//
        //=======================================================================================================//
        private Event _TEvent;

        private string SEvent = "Event";

        [Route("event")]
        public IActionResult Event()
        {
            _objek = _eventService.AmbilSemuaEvent();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SEvent), _objek);
            return Ok(_respon);
        }

        [Route("event")]
        [HttpPost]
        public IActionResult CreateEvent(Event parameter)
        {
            if (ModelState.IsValid)
            {
                _eventService.CreateEvent(parameter);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanTambahSukses(SEvent), parameter);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SEvent), null);
            return Ok(_respon);
        }
        [Route("event/{id}")]
        public IActionResult DetailEvent(string id)
        {
            _TEvent = _eventService.AmbilEventBerdasarkanId(id);

            if (_TEvent != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SEvent), _TEvent);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SEvent), null);
            return Ok(_respon);
        }
        [Route("event/{id}")]
        [HttpDelete]
        public IActionResult HapusEvent(string id)
        {
            try
            {
                _TEvent = _eventService.AmbilEventBerdasarkanId(id);

                if (_TEvent != null)
                {
                    _eventService.HapusEvent(id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanHapusSukses(SEvent), _TEvent);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SEvent), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SEvent), null);
                return Ok(_respon);
            }
        }
    }
}
