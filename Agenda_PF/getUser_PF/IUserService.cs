using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace getUser_PF
{
    public interface IUserService
    {
        Task<User> getUserAsync(int id);
    }
}
