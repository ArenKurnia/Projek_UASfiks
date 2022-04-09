using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.EventRepository
{
    public interface IEventRepository
    {
        Task<bool> CreateEventAsync(Event parameter);
        Task<bool> UpdateEventAsync(Event parameter);
        Task<bool> HapusEventAsync(Event parameter);
        Task<Event> CariEventAsync(string id);
        Task<List<Event>> AmbilSemuaEventAsync();

    }
}
