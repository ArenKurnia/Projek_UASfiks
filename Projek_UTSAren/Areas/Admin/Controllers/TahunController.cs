using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tahun parameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(parameter);
        }
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ubah = await _context.Tb_Tahun.FindAsync(id);
            if (ubah == null)
            {
                return NotFound();
            }
            return View(ubah);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Tahun ubah)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubah);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return NotFound(0);
                }
                return RedirectToAction("Index", "Tahun");
            }
            return View(ubah);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var cari = _context.Tb_Tahun.Where(x => x.Id_angkatan == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Tahun.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
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
