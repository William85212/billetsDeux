using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiTOL.Models;
using ApiTOL.Service;
using DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTOL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        Service_Commentaire Service = Service_Commentaire.Instance;
        [HttpGet("{id}")]
        public CommentaireApi Get(int id)
        {
            return Service.GetById(id);
        }
        
        public IEnumerable<CommentaireApi> Get()
        {
            return Service.GetAll();
        }
        [HttpDelete("Delete/{id:int}")]
        public void Delete(int id)
        {
            Service.Delete(id);
        }
        [HttpPut]
        public HttpResponseMessage Put(CommentaireApi commentaire)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        public HttpResponseMessage Post(CommentaireApi Commentaire)
        {
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
