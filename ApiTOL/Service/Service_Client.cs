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
    public class Service_Client : Irepo<ClientApi>
    {

        #region
        private static Service_Client _instance;

        public static Service_Client Istance
        {
            get
            {
                _instance = _instance ?? new Service_Client();
                return _instance;
            }
        }


        #endregion

        ServiceClient Service = ServiceClient.Instance;
        public ClientApi GetById(int id)
        {
            return Service.GetById(id).ClientToApi();
        }

        public IEnumerable<ClientApi> GetAll()
        {
            return Service.GetAll().ToList().Lta();
        }

        public int Create(ClientApi entity)
        {
            return Service.Create(entity.ClientToDal());
        }

        public void Delete(int id)
        {
            Service.Delete(id);
        }

        public void Update(ClientApi entity)
        {
            Service.Update(entity.ClientToDal());
        }
    }
}
