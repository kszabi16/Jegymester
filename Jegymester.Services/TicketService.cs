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
using AutoMapper;

namespace Jegymester.Services
{
    public interface ITicketService
    {
        Task<TicketDto?> BuyTicket(CreateTicketDto dto);
        Task<List<TicketDto>> GetUserTickets(int userId);
        Task<bool> CancelTicket(int ticketId, int userId);
    }
    public class TicketService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<TicketDto?> BuyTicket(CreateTicketDto dto)
        //{
        //    var screening = await _context.Screenings.FindAsync(dto.ScreeningId);
        //    if (screening == null)
        //    {
        //        throw new Exception("Nem létezik ilyen vetítés");
        //    }
        //    var ticket = _mapper.Map<Ticket>(dto);
        //    _context.Tickets.Add(ticket);
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<TicketDto>(ticket);
        //}

        public async Task<TicketDto?> BuyTicketForCustomer(CreateTicketDto dto)
        {
            var screening = await _context.Screenings.FindAsync(dto.ScreeningId);
            if (screening == null)
            {
                throw new Exception("Nem létezik ilyen vetítés");
            }

            var ticket = _mapper.Map<Ticket>(dto);

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<List<TicketDto>> GetTicketsForScreening(int screeningId)
        {
            var tickets = await _context.Tickets
             .Where(t => t.ScreeningId == screeningId)
             .ToListAsync();

            return _mapper.Map<List<TicketDto>>(tickets);
        }

       
    }
}
