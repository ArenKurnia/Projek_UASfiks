using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.EventService
{
    public interface IEventService
    {
        bool CreateEvent(Event parameter);
        bool UpdateEvent(Event parameter);
        bool HapusEvent(string id);
        List<Event> AmbilSemuaEvent();

    }
}
