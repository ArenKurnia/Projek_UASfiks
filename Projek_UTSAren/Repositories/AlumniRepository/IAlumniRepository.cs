using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.AlumniRepository
{
    public interface IAlumniRepository
    {   
        Task<bool> CreateAlumniAsync(Alumni alumni);
        Task<bool> UpdateAlumniAsync(Alumni alumni);
        Task<bool> HapusAlumniAsync(Alumni alumni);
        Task<Alumni> CariAlumniAsync(string id);
        Task<Alumni> AmbilAlumniBerdasarkanIdAsync(string id);
        Task<List<Alumni>> AmbilSemuaAlumniAsync();
        Task<List<User>> AmbilSemuaUserAsync();

    }
}
