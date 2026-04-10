using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DTOs
{
    //criar conta
    public class AuthrequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}