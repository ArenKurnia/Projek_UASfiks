using Microsoft.AspNetCore.Mvc;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services.EventService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event parameter)
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
            var ubah = await _context.Tb_Event.FindAsync(id);
            if (ubah == null)
            {
                return NotFound();
            }
            return View(ubah);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Event ubah)
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
                return RedirectToAction("Index", "Event");
            }
            return View(ubah);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var cari = _context.Tb_Event.Where(x => x.Id_event == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Event.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
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
