using billetsDeux.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace billetsDeux.Services
{
    public class SallesService
    {
        public static async Task<IEnumerable<SalleWeb>> Get()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await _client.GetAsync("Salle");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<SalleWeb>>(json);
        }
        public static async Task<SalleWeb>Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await client.GetAsync("Salle/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<SalleWeb>(json);
        }
    }
}
