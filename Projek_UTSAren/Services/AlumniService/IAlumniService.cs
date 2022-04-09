using Microsoft.AspNetCore.Http;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.AlumniService
{
    public interface IAlumniService
    {
        
        bool CreateAlumni(Alumni alumni, IFormFile Image);
        bool UpdateAlumni(Alumni alumni, IFormFile Image);
        bool HapusAlumni(string id);
        Alumni AmbilAlumniBerdasarkanId(string id);
        List<Alumni> AmbilSemuaAlumni();
        List<User> AmbilSemuaUser();
    }
}
