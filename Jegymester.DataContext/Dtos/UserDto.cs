using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Role { get; set; }
        
    }

    public class RegisterDto
    {
       
        public required string Name { get; set; }
        
        [EmailAddress]
        public required string Email { get; set; }
        
        public required string Password { get; set; }
     
        public required string Phone { get; set; }
    }

    public class LoginDto
    {
      
        [EmailAddress]
        public required string Email { get; set; }
        
        public required string Password { get; set; }

       
    }
    public class CreateUserDto
    {
        
        public required string Name { get; set; }
        
        [EmailAddress]
        public required string Email { get; set; }
        
        public required string Phone { get; set; }
        
        public required string Password { get; set; }
        public string Role { get; set; } = "RegularUser";
    }

}
