using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.TahunRepository
{
    public interface ITahunRepository
    {
        Task<bool> CreateTahunAsync(Tahun parameter);
        Task<bool> UpdateTahunAsync(Tahun parameter);
        Task<bool> HapusTahunAsync(Tahun parameter);
        Task<Tahun> CariTahunAsync(string id);
    }
}
