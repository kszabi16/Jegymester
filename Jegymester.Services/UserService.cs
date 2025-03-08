using Jegymester.DataContext.Context;
using Jegymester.DataContext.Dtos;
using Jegymester.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Jegymester.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> RegisterUser(RegisterUserDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
            {
                Console.WriteLine("Már létezik ilyen email");
            }


            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                //Jelszót meg kell hashelni
                Phone = dto.Phone,
                Role = Role.RegularUser
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role.ToString()
            };
        }

        public async Task<UserDto?> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            // Hibás belépési adatok befejezni jelszó hash

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role.ToString()
            };
        }

        public async Task<bool> UpdateUser(int userId, string email, string phoneNumber)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.Email = email;
            user.Phone = phoneNumber;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
