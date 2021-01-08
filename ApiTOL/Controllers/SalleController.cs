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
    public class SalleController : ControllerBase
    {
        Services_Salle service = Services_Salle.Instance;

        public IEnumerable<SalleApi> Get()
        {
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public SalleApi Get(int id)
        {
            return service.GetById(id);
        }
        [HttpDelete("Delete/{id:int}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
        [HttpPost]
        public HttpResponseMessage Post(SalleApi api)
        {
            service.Create(api);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpPut]
        public HttpResponseMessage Put(SalleApi api)
        {
            service.Update(api);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
