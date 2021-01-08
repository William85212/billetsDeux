using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Utils
{
    public static class MapperDetailsEvent
    {
        public static DetailsEventApi DeToDeApi(this DetailsEvent de)
        {
            DetailsEventApi dea = new DetailsEventApi
            {
                Id = de.Id,
                Date = de.Date,
                Description = de.Description,
                Duree = de.Duree,
                IdEvent = de.IdEvent,
                IdInfoEvent = de.IdInfoEvent,
                IdSalle = de.IdSalle,
                Image = de.Image,
                PlaceRestante = de.PlaceRestante,
                PrixPlace = de.PrixPlace,
                Realisateur = de.Realisateur
            };
            return dea;
        }
        public static List<DetailsEventApi> lta(this List<DetailsEvent> le)
        {
            List<DetailsEventApi> lea = new List<DetailsEventApi>();
            foreach (var item in le)
            {
                lea.Add(item.DeToDeApi());
            }
            return lea;
        }
    }
}
