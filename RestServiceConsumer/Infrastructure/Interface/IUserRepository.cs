using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceConsumer.Infrastructure
{
    public interface IUserRepository
    {
        Models.users GetUser(int id);

        void UpdateUser(Models.users user);

        Task<List<Models.users>> GetData();
    }
}
