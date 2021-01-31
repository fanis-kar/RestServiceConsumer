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
            int rowsAffected = userRepository.UpdateData(users);

            Console.WriteLine($"{rowsAffected} rows affected.");
            Console.ReadKey();
        }
    }
}
