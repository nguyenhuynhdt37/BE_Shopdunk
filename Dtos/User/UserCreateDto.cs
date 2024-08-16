using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BE_Shopdunk.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string? PasswordHash { get; set; }
    }
}