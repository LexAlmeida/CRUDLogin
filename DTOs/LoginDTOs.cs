using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DTOs
{
    public class AuthrequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}