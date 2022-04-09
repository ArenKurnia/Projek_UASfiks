using Projek_UTSAren.Models;
using Projek_UTSAren.Repositories.TahunRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.TahunService
{
    public class TahunService : ITahunService
    {
        private readonly ITahunRepository _tahunRepository;
        public TahunService(ITahunRepository parameter)
        {
            _tahunRepository = parameter;
        }
        public bool CreateTahun(Tahun parameter)
        {
            return _tahunRepository.CreateTahunAsync(parameter).Result;
        }

        public bool HapusTahun(string id)
        {
            var cari = _tahunRepository.CariTahunAsync(id).Result;
            return _tahunRepository.HapusTahunAsync(cari).Result;
        }

        public bool UpdateTahun(Tahun parameter)
        {
            return _tahunRepository.UpdateTahunAsync(parameter).Result;
        }
    }
}
