using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deleteUser_PF
{
    public interface IUserService
    {
        Task<int> deleteUserAsync(int id);
    }
}
