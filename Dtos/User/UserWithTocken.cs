using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Shopdunk.Dtos.User
{
    public class UserWithTocken : UserDto
    {
        public string? Token { set; get; }
    }
}