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
    public class MovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieDto>> GetAllMovies()
        {
            return await _context.Movies
                .Select(s => new MovieDto
                {
                    Title = s.Title,
                    Description = s.Description,
                    Length = s.Length,
                    Genre = s.Genre,
                    Director = s.Director
                }).ToListAsync();
        }

        public async Task<MovieDto?> AddMovie(CreateMovieDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Length = dto.Length,
                Genre = dto.Genre,
                Director = dto.Director
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return new MovieDto
            {
                Title = dto.Title,
                Length = dto.Length,
                Genre = dto.Genre
            };
        }

        public async Task<bool> UpdateMovie(int movieId, CreateMovieDto dto)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null) return false;

            

            movie.Title = dto.Title;
            movie.Length = dto.Length;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovie(int movieId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null) return false;

            
            

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
