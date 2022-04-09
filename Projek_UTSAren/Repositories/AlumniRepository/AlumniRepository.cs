using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.AlumniRepository
{
    public class AlumniRepository : IAlumniRepository
    {
        private readonly AppDbContext _context;
        public AlumniRepository(AppDbContext context)
        {
            _context = context;        
        }
        public async Task<bool> CreateAlumniAsync(Alumni alumni)
        {
            _context.Add(alumni);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HapusAlumniAsync(Alumni alumni)
        {
            _context.Remove(alumni);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Alumni> CariAlumniAsync(string id)
        {
            return await _context.Tb_Alumni.FirstOrDefaultAsync(x => x.NIM == id);
        }

        public async Task<bool> UpdateAlumniAsync(Alumni alumni)
        {
            _context.Update(alumni);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Alumni> AmbilAlumniBerdasarkanIdAsync(string id)
        {
            return await _context.Tb_Alumni.Include(x => x.Roles).FirstOrDefaultAsync(x => x.NIM == id);
        }

        public async Task<List<Alumni>> AmbilSemuaAlumniAsync()
        {
            return await _context.Tb_Alumni.Include(x => x.Roles).ToListAsync();
        }

        public async Task<List<User>> AmbilSemuaUserAsync()
        {
            return await _context.Tb_User.Include(x => x.Roles).ToListAsync();
        }
    }
}
