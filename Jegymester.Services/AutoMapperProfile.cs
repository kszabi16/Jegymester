using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Jegymester.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataContext.Entities.Movie, DataContext.Dtos.MovieDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateMovieDto, DataContext.Entities.Movie>();
            CreateMap<DataContext.Entities.Screening, DataContext.Dtos.ScreeningDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateScreeningDto, DataContext.Entities.Screening>();
            CreateMap<DataContext.Entities.Ticket, DataContext.Dtos.TicketDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateTicketDto, DataContext.Entities.Ticket>();
        }

    }
}
