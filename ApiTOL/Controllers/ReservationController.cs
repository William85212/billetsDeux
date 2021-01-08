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
    public class ReservationController : ControllerBase
    {
        Service_Reservation service = Service_Reservation.Instance;

        public IEnumerable<ReservationApi> Get()
        {
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public ReservationApi Get(int id)
        {
            return service.GetById(id);
        }
        [HttpDelete("Delete/{id:int}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
        [HttpPost]
        public HttpResponseMessage Post(ReservationApi apiReservation)
        {
            service.Create(apiReservation);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpPut]
        public HttpResponseMessage Put(ReservationApi apireservation)
        {
            service.Update(apireservation);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
