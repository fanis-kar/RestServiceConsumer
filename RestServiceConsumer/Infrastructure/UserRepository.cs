using Newtonsoft.Json;
using RestServiceConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceConsumer.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<users>> GetData()
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Add("Authorization", "Bearer " + bearerToken);

            HttpResponseMessage response = await client.GetAsync("users");

            if (!response.IsSuccessStatusCode)
                return null;

            string jsonResult = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<users>>(jsonResult);

            return users;
        }

        public users GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(users user)
        {
            throw new NotImplementedException();
        }
    }
}
