using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.EventService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.User.Controllers
{
    [Area("User")]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEventService _eventService;
        public EventController(AppDbContext context, IEventService even)
        {
            _context = context;
            _eventService = even;
        }
        public IActionResult Index()
        {
            var data2 = _context.Tb_Event.ToList();
            return View(data2);
        }
        public IActionResult Detail(string id)
        {
            Event cari = _eventService.AmbilEventBerdasarkanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }
    }
}
