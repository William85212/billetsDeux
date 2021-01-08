using billetsDeux.Models;
using billetsDeux.Models.VueModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace billetsDeux.Services
{
    public class EventService
    {
        public static async Task<IEnumerable<EventWeb>> GetAllEvent()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await client.GetAsync("Event");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<EventWeb>>(json);
        }
        public static async Task<EventWeb> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await client.GetAsync("Event/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<EventWeb>(json);

        }

        public static async Task<List<DetailsEventWeb>> GetDetailsEventByid(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await client.GetAsync("DetailsEvent/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<DetailsEventWeb>>(json);
        }
    }
}
