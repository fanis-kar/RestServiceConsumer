using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceConsumer.Infrastructure
{
    public interface IUserRepository
    {
        Task<List<Models.users>> GetData();

        int UpdateData(List<Models.users> usersAPI);
    }
}
