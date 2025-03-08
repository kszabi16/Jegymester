using Jegymester.DataContext.Dtos;
using Jegymester.DataContext.Entities;
using Jegymester.DataContext.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Jegymester.Services
{
    public class ScreeningService
    {
        private readonly AppDbContext _context;

        public ScreeningService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ScreeningDto>> GetAllScreenings()
        {
            return await _context.Screenings
                .Select(s => new ScreeningDto
                {
                    Id = s.Id,
                    MovieId = s.MovieId,
                    Location = s.Location,
                    StartTime = s.StartTime
                }).ToListAsync();
        }

        public async Task<ScreeningDto?> AddScreening(CreateScreeningDto dto)
        {
            var screening = new Screening
            {
                MovieId = dto.MovieId,
                Location = dto.Location,
                StartTime = dto.StartTime
            };

            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();

            return new ScreeningDto
            {
                MovieId = dto.MovieId,
                Location = dto.Location,
                StartTime = dto.StartTime
            };
        }

        public async Task<bool> UpdateScreening(int screeningId, CreateScreeningDto dto)
        {
            var screening = await _context.Screenings.FindAsync(screeningId);
            if (screening == null) return false;

            screening.MovieId = dto.MovieId;
            screening.StartTime = dto.StartTime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteScreening(int screeningId)
        {
            var screening = await _context.Screenings.FindAsync(screeningId);
            if (screening == null) return false;

            // Csak akkor törölhető, ha nincs még jegyvásárlás
            bool hasTickets = await _context.Tickets.AnyAsync(t => t.ScreeningId == screeningId);
            if (hasTickets) return false;

            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
