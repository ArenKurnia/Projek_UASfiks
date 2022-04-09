using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.AlumniService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Alumni alumni, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _alumniService.CreateAlumni(alumni, Image);

                return RedirectToAction("Index");
            }
            return View(alumni);
        }
        public IActionResult Update(string id)
        {
            var cari = _alumniService.AmbilAlumniBerdasarkanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(Alumni ubah, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                var cari = _alumniService.AmbilAlumniBerdasarkanId(ubah.NIM);
                if (cari != null)
                {
                    _alumniService.UpdateAlumni(ubah, Image);
                    return Redirect("/Admin/Alumni/Detail/" + ubah.NIM);

                }
                return NotFound(0);
            }
            return View(ubah);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var cari = _context.Tb_Alumni.Where(x => x.NIM == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Alumni.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
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
