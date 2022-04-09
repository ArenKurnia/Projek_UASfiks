using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
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
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data2 = _context.Tb_Event.ToList();
            return View(data2);
        }
        public IActionResult Detail(string id)
        {
            var details = new List<Models.Event>();
            var detail = _context.Tb_Event.Where(x => x.Id_event == id).ToList();
            if (detail == null)
            {
                return NotFound();
            }
            ViewBag.details = detail;
            return View();
        }
    }
}
