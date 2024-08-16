using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Dtos;
using BE_Shopdunk.Dtos.User;
using BE_Shopdunk.Model;

namespace BE_Shopdunk.Mappers
{
    public static class UserMapper
    {
        public static User UserCreateDtoToUser(this UserCreateDto userCreateDto)
        {
            return new User
            {
                UserName = userCreateDto.UserName,
                Email = userCreateDto.Email,
                PasswordHash = userCreateDto.PasswordHash
            };
        }

        public static UserDto UserToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Email = user.Email,
                Role = new RoleDto
                {
                    Id = user.Role?.Id.ToString(),
                    Name = user.Role?.Name,
                    Description = user.Role?.Description
                }
            };
        }
    }
}