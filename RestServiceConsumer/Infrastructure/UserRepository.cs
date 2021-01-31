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

            //=======================

            using (var db = new DBTestEntities())
            {
                foreach (var user in users)
                {
                    var tmpUser = new users()
                    {
                        id = user.id,
                        name = user.name,
                        username = user.username,
                        email = user.email,
                        phone = user.phone,
                        website = user.website
                    };

                    db.users.Add(tmpUser);
                    //db.SaveChanges();                  
                }
            }
            var x = GetToken();
            Console.WriteLine(x);
            //=======================


            return users;
        }

        public int UpdateData(List<users> usersAPI)
        {
            using (var db = new DBTestEntities())
            {
                foreach (var userAPI in usersAPI)
                {
                    var usersInDB = db.users.Where(u => u.id == userAPI.id).ToList();
                    usersInDB.ForEach(u => {
                        u.name = userAPI.name;
                        u.username = userAPI.username;
                        u.email = userAPI.email;
                        u.phone = userAPI.phone;
                        u.website = userAPI.website;
                    });
                }

                return db.SaveChanges();
            }
        }

        private static string GetToken()
        {
            return "abcdefg";
        }
    }
}
