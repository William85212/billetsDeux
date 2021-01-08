using ApiTOL.Models;
using ApiTOL.Utils;
using DAL.IRepo;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTOL.Service
{
    public class Service_Reservation : Irepo<ReservationApi>
    {
        #region singleton

        private static Service_Reservation _instance;

        public static Service_Reservation Instance
        {
            get
            {
                _instance = _instance ?? new Service_Reservation();
                return _instance;
            }
        }

        protected Service_Reservation()
        {

        }

        #endregion

        ServicesReservation services = ServicesReservation.Instance;

        public ReservationApi GetById(int id)
        {
            return services.GetById(id).toA();
        }

        public IEnumerable<ReservationApi> GetAll()
        {
            return services.GetAll().ToList().lta();
        }

        public int Create(ReservationApi entity)
        {
            return services.Create(entity.toD());
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }

        public void Update(ReservationApi entity)
        {
            services.Update(entity.toD());
        }
    }
}
