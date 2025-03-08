using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jegymester.DataContext.Dtos;
using Jegymester.DataContext.Entities;

namespace Jegymester.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Movie mapping
            CreateMap<DataContext.Entities.Movie, DataContext.Dtos.MovieDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateMovieDto, DataContext.Entities.Movie>();
            //Screening mapping
            CreateMap<DataContext.Entities.Screening, DataContext.Dtos.ScreeningDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateScreeningDto, DataContext.Entities.Screening>();
            //Ticket mapping
            CreateMap<DataContext.Entities.Ticket, DataContext.Dtos.TicketDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateTicketDto, DataContext.Entities.Ticket>();
            CreateMap<DataContext.Dtos.TicketDto, DataContext.Entities.Ticket>();
            //User mapping
            CreateMap<DataContext.Entities.User, DataContext.Dtos.UserDto>().ReverseMap();
            CreateMap<DataContext.Dtos.CreateUserDto, DataContext.Entities.User>();
            CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<LoginDto, User>();
           
        }


    }
}
