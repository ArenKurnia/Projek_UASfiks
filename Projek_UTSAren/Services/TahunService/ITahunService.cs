using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.TahunService
{
    public interface ITahunService
    {
        bool CreateTahun(Tahun parameter);
        bool UpdateTahun(Tahun parameter);
        bool HapusTahun(string id);
    }
}
