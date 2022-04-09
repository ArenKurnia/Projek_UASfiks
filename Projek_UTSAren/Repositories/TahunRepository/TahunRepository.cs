using Microsoft.EntityFrameworkCore;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.TahunRepository
{
    public class TahunRepository : ITahunRepository
    {
        private readonly AppDbContext _context;
        public TahunRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateTahunAsync(Tahun parameter)
        {
            _context.Add(parameter);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HapusTahunAsync(Tahun parameter)
        {
            _context.Remove(parameter);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Tahun> CariTahunAsync(string id)
        {
            return await _context.Tb_Tahun.FirstOrDefaultAsync(x => x.Id_angkatan == id);
        }

        public async Task<bool> UpdateTahunAsync(Tahun parameter)
        {
            _context.Update(parameter);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
