using billetsDeux.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace billetsDeux.Services
{
    public class ClientService
    {
        public static async Task<IEnumerable<ClientWeb>> Get()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await _client.GetAsync("Client");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<ClientWeb>>(json);
        }


        public static async Task<ClientWeb> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage message = await client.GetAsync("Client/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ClientWeb>(json);
        }

        public static async void Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            using (HttpResponseMessage message = await client.DeleteAsync("Client/" + id))
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }

        public static async void Post(ClientWeb clientWeb)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            string json = JsonConvert.SerializeObject(clientWeb);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage reponse = await client.PostAsync("Client", content))
            {
                if (!reponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }

        }
    }
}
