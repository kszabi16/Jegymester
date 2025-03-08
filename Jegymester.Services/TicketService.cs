using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jegymester.DataContext.Entities;
using Jegymester.DataContext.Dtos;
using Microsoft.EntityFrameworkCore;
using Jegymester.DataContext.Context;
using System.Threading.Channels;

namespace Jegymester.Services
{
    public class TicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketDto?> BuyTicket(CreateTicketDto dto)
        {
            var screening = await _context.Screenings.FindAsync(dto.ScreeningId);
            if (screening == null) return null;

            var ticket = new Ticket
            {
                ScreeningId = dto.ScreeningId,
                UserId = dto.UserId,
                BuyerEmail = dto.BuyerEmail,
                BuyerPhone = dto.BuyerPhone
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return new TicketDto
            {
                Id = ticket.Id,
                ScreeningId = ticket.ScreeningId,
                UserId = ticket.UserId,
                BuyerEmail = dto.BuyerEmail,
                BuyerPhone = dto.BuyerPhone
            };
        }

        public async Task<List<TicketDto>> GetUserTickets(int userId)
        {
            return await _context.Tickets
                .Where(t => t.UserId == userId)
                .Select(t => new TicketDto
                {
                    Id = t.Id,
                    ScreeningId = t.ScreeningId,
                    UserId = t.UserId,
                }).ToListAsync();
        }

        public async Task<bool> CancelTicket(int ticketId, int userId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId && t.UserId == userId);
            if (ticket == null) return false;

            var screening = await _context.Screenings.FindAsync(ticket.ScreeningId);
            if (screening == null || screening.StartTime < DateTime.Now.AddHours(4))
                Console.WriteLine("Már nem lehet törölni"); 

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
