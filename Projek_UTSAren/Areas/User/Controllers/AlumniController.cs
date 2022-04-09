using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.AlumniService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.User.Controllers
{
    [Area("User")]
    public class AlumniController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAlumniService _alumniService;
        public AlumniController(AppDbContext context, IAlumniService alumni)
        {
            _context = context;
            _alumniService = alumni;
        }
        public IActionResult Index()
        {
            var data = _context.Tb_Alumni.ToList();
            return View(data);
        }
        public IActionResult Detail(string id)
        {
            Alumni cari = _alumniService.AmbilAlumniBerdasarkanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }
    }
}
