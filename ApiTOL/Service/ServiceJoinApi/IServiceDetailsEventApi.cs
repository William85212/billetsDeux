using ApiTOL.Models;
using System.Collections.Generic;

namespace ApiTOL.Service.ServiceJoinApi
{
    public interface IServiceDetailsEventApi
    {
        List<DetailsEventApi> GetInfoEventById(int id);
    }
}