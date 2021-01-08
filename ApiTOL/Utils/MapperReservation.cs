using ApiTOL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Utils
{
    public static class MapperReservation
    {
        public static Reservation toD(this ReservationApi api)
        {
            Reservation rd = new Reservation
            {
                Id = api.Id,
                DateReservation = api.DateReservation,
                IdClient = api.IdClient,
                IdEvent = api.IdEvent,
                NbrPlace = api.NbrPlace,
                PrixTatal = api.PrixTatal
            };
            return rd;
        }

        public static ReservationApi toA(this Reservation rd)
        {
            ReservationApi api = new ReservationApi
            {
                Id = rd.Id,
                DateReservation = rd.DateReservation,
                IdClient = rd.IdClient,
                IdEvent = rd.IdEvent,
                NbrPlace = rd.NbrPlace,
                PrixTatal = rd.PrixTatal
            };
            return api;
        }

        public static List<Reservation> ltd(this List<ReservationApi> apil)
        {
            List<Reservation> lr = new List<Reservation>();

            foreach (ReservationApi item in apil)
            {
                lr.Add(item.toD());
            }
            return lr;
        }


        public static List<ReservationApi> lta(this List<Reservation> lr)
        {
            List<ReservationApi> la = new List<ReservationApi>();

            foreach (Reservation item in lr)
            {
                la.Add(item.toA());
            }
            return la;
        }
    }
}
