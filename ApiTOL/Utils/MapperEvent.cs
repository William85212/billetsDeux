using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Utils
{
    public static class MapperEvent
    {
        public static Event toD( this EventApi api)
        {
            Event e = new Event
            {
                Id = api.Id,
                Description = api.Description,
                Duree = api.Duree,
                Image = api.Image,
                NomSpectacle = api.NomSpectacle,
                Realisateur = api.Realisateur
            };
            return e;
        }

        public static EventApi toA(this Event e)
        {
            EventApi a = new EventApi
            {
                Id = e.Id,
                Description = e.Description,
                Duree = e.Duree,
                Image = e.Image,
                NomSpectacle = e.NomSpectacle,
                Realisateur = e.Realisateur
            };
            return a;
        }

        public static IEnumerable<Event> ltD(this List<EventApi> api)
        {
            List<Event> list = new List<Event>();

            foreach (EventApi item in api)
            {
                list.Add(item.toD());
            }
          
            return list;
        }

        public static IEnumerable<EventApi> lta(this List<Event> le)
        {
            List<EventApi> list = new List<EventApi>();

            foreach (Event item in le)
            {
                list.Add(item.toA());
            }

            return list;
        }
    }
}
