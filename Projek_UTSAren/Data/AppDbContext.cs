using Projek_UTSAren.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }
        public virtual DbSet<Alumni> Tb_Alumni { get; set; }
        public virtual DbSet<Event> Tb_Event { get; set; }
        public virtual DbSet<Tahun> Tb_Tahun { get; set; }
        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
    }
}
