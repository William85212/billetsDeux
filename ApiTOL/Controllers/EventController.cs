using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiTOL.Models;
using ApiTOL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTOL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        Service_Event service = Service_Event.Istance;

        public IEnumerable<EventApi> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public EventApi Get(int id)
        {
            return service.GetById(id);
        }

        [HttpDelete("Delete/{id:int}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
        [HttpPost]
        public HttpResponseMessage Post(EventApi e)
        {
            service.Create(e);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpPut]
        public HttpResponseMessage Put(EventApi ea)
        {
            service.Update(ea);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
