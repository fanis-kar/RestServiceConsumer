using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceConsumer
{
    class Program
    {
        static void Main()
        {
            var jsonResult = GetData().Result;
            var users = JsonConvert.DeserializeObject<List<Models.users>>(jsonResult);

            Console.WriteLine(users[0].email);
            Console.ReadKey();
        }

        static async Task<string> GetData()
        {
            var url = "https://jsonplaceholder.typicode.com/users";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                string strResult = await response.Content.ReadAsStringAsync();
                return strResult;
            }
        }
    }
}
