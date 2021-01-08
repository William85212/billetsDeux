using billetsDeux.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billetsDeux.Infrastructure
{
    public class SessionTools : ISessionTools
    {
        private ISession Session { get; }
        public SessionTools(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }


        public string Test
        {
            get { return Session.GetString(nameof(Test)); }
            set { Session.SetString(nameof(Test), (value)); }
        }

        public ClientWeb clientWeb
        {
            get { return (Session.Keys.Contains(nameof(clientWeb))) ? JsonConvert.DeserializeObject<ClientWeb>(Session.GetString(nameof(clientWeb))) : null; }
            set { Session.SetString(nameof(clientWeb), JsonConvert.SerializeObject(value)); }
        }
    }
}
