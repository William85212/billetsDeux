using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Utils
{
    public static class MapperSalles
    {
        public static Salles toD(this SalleApi api)
        {
            Salles s = new Salles
            {
                Id = api.Id,
                AdresseSalle = api.AdresseSalle,
                Capacite = api.Capacite,
                NomSalle = api.NomSalle,
                ImageSalles = api.ImageSalles,
                HistoireSalle = api.HistoireSalle
            };
            return s;
        }
        public static SalleApi toA(this Salles s)
        {
            return new SalleApi
            {
                Id = s.Id,
                AdresseSalle = s.AdresseSalle,
                Capacite = s.Capacite,
                NomSalle = s.NomSalle,
                ImageSalles = s.ImageSalles,
                HistoireSalle = s.HistoireSalle
            };
        }

        public static List<Salles> ltd(this List<SalleApi> api)
        {
            List<Salles> list = new List<Salles>();

            foreach (SalleApi item in api)
            {
                list.Add(item.toD());
            }
            return list;
        }

        public static List<SalleApi> lta(this List<Salles> s )
        {
            List<SalleApi> a = new List<SalleApi>();
            foreach (Salles item in s)
            {
                a.Add(item.toA());
            }
            return a;
        }
    }
}
