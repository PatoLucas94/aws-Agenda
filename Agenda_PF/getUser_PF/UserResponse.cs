using System;
using System.Collections.Generic;
using System.Text;

namespace getUser_PF
{
    public class UserResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public User Data { get; set; }
    }
}
