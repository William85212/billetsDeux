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
    public class Service_InfoEvent : Irepo<InfoEventApi>
    {
        #region singleton

        private static Service_InfoEvent _instance;

        public static Service_InfoEvent Instance
        {
            get
            {
                _instance = _instance ?? new Service_InfoEvent();
                return _instance;
            }
        }

        protected Service_InfoEvent()
        {

        }
        #endregion

        ServicesInfoReservation service = ServicesInfoReservation.Instance;

        public InfoEventApi GetById(int id)
        {
            return service.GetById(id).toA();
        }

        public IEnumerable<InfoEventApi> GetAll()
        {
            return service.GetAll().ToList().lta();
        }

        public int Create(InfoEventApi entity)
        {
            return service.Create(entity.toD());
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Update(InfoEventApi entity)
        {
            service.Update(entity.toD());
        }
    }
}
