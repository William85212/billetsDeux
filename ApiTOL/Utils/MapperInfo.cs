using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Utils
{
    public static class MapperInfo
    {
        public static InfoEvent toD(this InfoEventApi api)
        {
            InfoEvent eve = new InfoEvent
            {
                Id = api.Id,
                DateEvent = api.DateEvent,
                IdEvent = api.IdEvent, 
                IdSalle = api.IdSalle,
                PlaceRestante = api.PlaceRestante,
                PrixPlace = api.PrixPlace 
            };
            return eve;
        }

        public static InfoEventApi toA(this InfoEvent eve)
        {
            InfoEventApi api = new InfoEventApi
            {
                Id = eve.Id,
                DateEvent = eve.DateEvent,
                IdEvent = eve.IdEvent,
                IdSalle = eve.IdSalle,
                PlaceRestante = eve.PlaceRestante,
                PrixPlace = eve.PrixPlace
            };
            return api;
        }

        public static List<InfoEvent> ltd(this List<InfoEventApi> apilist)
        {
            List<InfoEvent> listevent = new List<InfoEvent>();

            foreach (InfoEventApi info in apilist)
            {
                listevent.Add(info.toD());
            }
            return listevent;
        }

        public static List<InfoEventApi> lta(this List<InfoEvent> listevent)
        {
            List<InfoEventApi> listapi = new List<InfoEventApi>();

            foreach (InfoEvent item in listevent)
            {
                listapi.Add(item.toA());
            }

            return listapi;
        }
    }
}
