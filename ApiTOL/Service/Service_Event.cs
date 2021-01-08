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
    public class Service_Event : Irepo<EventApi>
    {
        #region Singleton

        private static Service_Event _instance;

        public static Service_Event Istance
        {
            get
            {
                _instance = _instance ?? new Service_Event();
                return _instance;
            }
        }

        #endregion

        ServicesEvent Services = ServicesEvent.Instance;

        public int Create(EventApi entity)
        {
            return Services.Create(entity.toD());
        }

        public void Delete(int id)
        {
            Services.Delete(id);
        }

        public IEnumerable<EventApi> GetAll()
        {
            return Services.GetAll().ToList().lta();
        }

        public EventApi GetById(int id)
        {
            return Services.GetById(id).toA();
        }

        public void Update(EventApi entity)
        {
            Services.Update(entity.toD());
        }
    }
}
