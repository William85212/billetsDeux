using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTOL.Models;
using ApiTOL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTOL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoEventController : ControllerBase
    {
        Service_InfoEvent service = Service_InfoEvent.Instance;

        [HttpGet("{id}")]
        public InfoEventApi Get(int id)
        {
            return service.GetById(id);
        }
        public IEnumerable<InfoEventApi> Get()
        {
            return service.GetAll();
        }
        [HttpPost]
        public int Post(InfoEventApi api)
        {
            return service.Create(api);
        }
        [HttpPut]
        public void Put(InfoEventApi api)
        {
            service.Update(api);
        }
        [HttpDelete("delete/{id:int}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }

    }
}
