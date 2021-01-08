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
    public class Services_Salle : Irepo<SalleApi>
    {
        #region singleton
        private static Services_Salle _instance;

        public static Services_Salle Instance
        {
            get
            {
                _instance = _instance ?? new Services_Salle();
                return _instance;
            }
        }
        protected Services_Salle()
        {

        }
        #endregion

        ServicesSalle service = ServicesSalle.Instance;

        public SalleApi GetById(int id)
        {
            return service.GetById(id).toA();
        }

        public IEnumerable<SalleApi> GetAll()
        {
            return service.GetAll().ToList().lta();
        }

        public int Create(SalleApi entity)
        {
            return service.Create(entity.toD());
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }
        public void Update(SalleApi entity)
        {
            service.Update(entity.toD());
        }
    }
}
