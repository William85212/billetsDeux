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
    public class ClientController : ControllerBase 
    {
        Service_Client Service = Service_Client.Istance;

        public IEnumerable<ClientApi>Get()
        {
            return Service.GetAll();
        }
        [HttpGet("{id}")]
        public ClientApi GetOne(int id)
        {
            return Service.GetById(id);
        }
        [HttpPost]
        public HttpResponseMessage Post(ClientApi api)
        {
            Service.Create(api);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            Service.Delete(id);
        }
        [HttpPut]
        public HttpResponseMessage Put(ClientApi api)
        {
            Service.Update(api);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
