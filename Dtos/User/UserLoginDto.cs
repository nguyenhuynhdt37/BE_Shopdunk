using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Shopdunk.Dtos.User
{
    public class UserLoginDto
    {
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
    }
}