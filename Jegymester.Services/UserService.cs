using Jegymester.DataContext.Context;
using Jegymester.DataContext.Dtos;
using Jegymester.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Cryptography;

namespace Jegymester.Services
{
   
         public interface IUserService
         {
                Task<UserDto> Register(RegisterDto dto);
                Task<UserDto> Login(LoginDto dto);
        //Task<UserDto> Update(int userId, string email, string phone);
                Task<List<Ticket>> GetUserTickets(int userId);
                //Task<TicketDelete> CancelTicket(int ticketId, int userId);



    }
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto?> Register(RegisterDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
            {
                throw new Exception("Már létezik ilyen email");
            }

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = HashPassword(dto.Password);


            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || user.PasswordHash != HashPassword(dto.Password))
            {
                throw new Exception("Hibás belépési adatok");
            }

            return _mapper.Map<UserDto>(user);
        }
        private string HashPassword(string password)
        {
            //byte[] bytes = Encoding.UTF8.GetBytes(password); // 2. A jelszót átalakítjuk byte tömbbé
            //byte[] hashBytes = sha512.ComputeHash(bytes); // 3. Hash kiszámítása (512 bites)
            //return Convert.ToBase64String(hashBytes); // 4. Hash Base64 formátumra konvertálása ha nem működik, ennek utána nézni
            return password;
        }


        public async Task<List<Ticket>> GetUserTickets(int userId)
        {
            var user = _context.Users.Include(u => u.Tickets).FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("Felhasználó nem található");
            }


            return user.Tickets;
        }
        //public async Task<TicketDelete> CancelTicket(int ticketId, int userId)
        //{
        //    if (userId == 0)
        //    {
        //        return TicketDelete.NotLoggedin;
        //    }

        //    var ticket = await _context.Tickets
        //        .Include(t => t.Screening)
        //        .FirstOrDefaultAsync(t => t.Id == ticketId);

        //    if (ticket == null)
        //        return TicketDelete.TicketNotFound;

        //    // Ellenőrizzük, hogy a jegy a felhasználóhoz tartozik
        //    bool isOwner = (ticket.UserId == userId) || (ticket.UserId == null);
        //    if (!isOwner)
        //        return TicketDelete.NotOwner;

        //    // Ellenőrizzük, hogy a vetítés legalább 4 órára van-e
        //    if (ticket.Screening.StartTime < DateTime.UtcNow.AddHours(4))
        //        return TicketDelete.ScreeningTooSoon;

        //    _context.Tickets.Remove(ticket);
        //    await _context.SaveChangesAsync();
        //    return TicketDelete.Success;

        //}
    }
}
