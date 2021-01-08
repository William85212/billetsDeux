using ApiTOL.Models;
using DAL.Services.ServicesSpecialJoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTOL.Utils;

namespace ApiTOL.Service.ServiceJoinApi
{
    public class ServiceDetailsEventApi : IServiceDetailsEventApi
    {
        ServicesDetailEvent service = ServicesDetailEvent.Instance;

        public List<DetailsEventApi> GetInfoEventById(int id)
        {
            return service.GetInfoEventById(id).lta();
        }
    }
}
