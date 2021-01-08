using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTOL.Models;
using ApiTOL.Service.ServiceJoinApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTOL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsEventController : ControllerBase
    {
        private readonly IServiceDetailsEventApi _serviceDetailsEventApi;

        public DetailsEventController(IServiceDetailsEventApi serviceDetailsEventApi)
        {
            _serviceDetailsEventApi = serviceDetailsEventApi;
        }

        [HttpGet("{id}")]
        public List<DetailsEventApi> GetDetailsEvent(int id)
        {
            return _serviceDetailsEventApi.GetInfoEventById(id);
        }

    }
}
