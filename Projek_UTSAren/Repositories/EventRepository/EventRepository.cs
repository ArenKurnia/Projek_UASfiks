using Microsoft.EntityFrameworkCore;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.EventRepository
{
    public class EventRepository:IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEventAsync(Event parameter)
        {
            _context.Add(parameter);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HapusEventAsync(Event parameter)
        {
            _context.Remove(parameter);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Event> CariEventAsync(string id)
        {
            return await _context.Tb_Event.FirstOrDefaultAsync(x => x.Id_event == id);
        }

        public async Task<bool> UpdateEventAsync(Event parameter)
        {
            _context.Update(parameter);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<Event>> AmbilSemuaEventAsync()
        {
            return await _context.Tb_Event.Include(x => x.Nama_angkatan).ToListAsync();
        }

        public async Task<Event> AmbilEventBerdasarkanIdAsync(string id)
        {
            return await _context.Tb_Event.Include(x => x.Nama_angkatan).FirstOrDefaultAsync(x => x.Id_event == id);
        }
    }
}
