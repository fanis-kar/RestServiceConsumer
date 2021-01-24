using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestServiceConsumer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace RestServiceConsumer
{
    class Program
    {
        static void Main()
        {
            var userRepository = new UserRepository();
            var users = userRepository.GetData().Result;

            foreach(var user in users)
            {
                var db = new Models.DBTestEntities();

                var tmpUser = new Models.users() {
                    id = user.id,
                    name = user.name,
                    username = user.username,
                    email = user.email,
                    phone = user.phone,
                    website = user.website
                };

                db.users.Add(tmpUser);
                //db.SaveChanges();

                Console.WriteLine(user.id + " " + user.username);
            }

            Console.ReadKey();
        }
    }
}
