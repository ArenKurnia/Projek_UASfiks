using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.AlumniService;
using Projek_UTSAren.Services.EventService;
using Projek_UTSAren.Services.TahunService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAlumniService _alumniService;
        private readonly IEventService _eventService;
        public HomeController(IAlumniService alumni, IEventService even)
        {
            _alumniService = alumni;
            _eventService = even;        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            var banyakData = new Dashboard();

            banyakData.alumni = _alumniService.AmbilSemuaAlumni();
            banyakData.user = _alumniService.AmbilSemuaUser();
            banyakData.even = _eventService.AmbilSemuaEvent();
            return View(banyakData);
        }
    }
}
