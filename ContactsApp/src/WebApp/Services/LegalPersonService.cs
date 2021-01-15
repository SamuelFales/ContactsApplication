using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class LegalPersonService : ILegalPersonService
    {
        public bool Delete(int personId)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:44394/api/LegalPerson/delete/" + personId.ToString());

            var postResult = httpClient.SendAsync(request).GetAwaiter().GetResult();

            return postResult.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<LegalPersonModel>> GetAll()
        {
            var persons = new List<LegalPersonModel>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:44394/api/LegalPerson/getAll").ConfigureAwait(false))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    persons = JsonConvert.DeserializeObject<List<LegalPersonModel>>(apiResponse);
                }
            }

            return persons;
        }

        public async Task<LegalPersonModel> GetById(int personId)
        {
            var persons = new LegalPersonModel();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:44394/api/LegalPerson/get/" + personId.ToString()).ConfigureAwait(false))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    persons = JsonConvert.DeserializeObject<LegalPersonModel>(apiResponse);
                }
            }

            return persons;
        }

        public async Task<bool> Save(LegalPersonModel person)
        {
            string data = JsonConvert.SerializeObject(person, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:44394/api/LegalPerson/save")
            {
                Content = new StringContent(data)
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var postResult = await httpClient.SendAsync(request).ConfigureAwait(false);

            return postResult.IsSuccessStatusCode;

        }

        public async Task<bool> Update(LegalPersonModel person)
        {
            string data = JsonConvert.SerializeObject(person, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:44394/api/LegalPerson/update")
            {
                Content = new StringContent(data)
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var postResult = await httpClient.SendAsync(request).ConfigureAwait(false);

            return postResult.IsSuccessStatusCode;
        }
    }
}
