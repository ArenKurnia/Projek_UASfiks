using Projek_UTSAren.Models;
using Projek_UTSAren.Repositories.EventRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.EventService
{
    public class EventService:IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository parameter)
        {
            _eventRepository = parameter;
        }

        public bool CreateEvent(Event parameter)
        {
            return _eventRepository.CreateEventAsync(parameter).Result;
        }

        public bool HapusEvent(string id)
        {
            var cari = _eventRepository.CariEventAsync(id).Result;
            return _eventRepository.HapusEventAsync(cari).Result;
        }

        public bool UpdateEvent(Event parameter)
        {
            return _eventRepository.UpdateEventAsync(parameter).Result;
        }
        public List<Event> AmbilSemuaEvent()
        {
            return _eventRepository.AmbilSemuaEventAsync().Result;
        }
    }
}
