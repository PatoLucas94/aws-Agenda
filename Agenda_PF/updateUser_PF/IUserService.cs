using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace updateUser_PF
{
    public interface IUserService
    {
        Task<User> updateUserAsync(User updatedUser);
    }
}
