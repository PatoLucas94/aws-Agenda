using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace getAllUsers_PF
{
    public interface IUserService
    {
        Task<User[]> getAllUsersAsync();
    }
}
