using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace createUser_PF
{
    public interface IUserService
    {
        Task<int> createUserAsync(User user);
    }
}
