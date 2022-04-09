using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.User.Controllers
{
    [Area("User")]
    public class TahunController : Controller
    {
        private readonly AppDbContext _context;
        public TahunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data3 = _context.Tb_Tahun.ToList();
            return View(data3);
        }
        public IActionResult Detail(string id)
        {
            var details = new List<Models.Tahun>();
            var detail = _context.Tb_Tahun.Where(x => x.Id_angkatan == id).ToList();
            if (detail == null)
            {
                return NotFound();
            }
            ViewBag.details = detail;
            return View();
        }
    }
}
