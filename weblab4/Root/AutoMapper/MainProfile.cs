using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Abstractions.DTO;
using BLL.Abstractions.DTO.Page;
using BLL.Abstractions.DTO.Media;
using DAL.Abstractions.Models;

namespace Root.AutoMapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<TicketLowInfo, Ticket>().ReverseMap();
            CreateMap<TourLowInfo, Tour>().ReverseMap();
            CreateMap<UserLowInfo, User>().ReverseMap();

            CreateMap<TicketDTO, Ticket>()
                                            .ForMember(x => x.UserId, y => y.MapFrom(z => z.User == null ? 0 : z.User.UserId))
                                            .ForMember(x => x.TourId, y => y.MapFrom(z => z.Tour == null ? 0 : z.Tour.TourId))
                                            .ForMember(x => x.User, y => y.MapFrom(z => default(object)))
                                            .ForMember(x => x.Tour, y => y.MapFrom(z => default(object)))
                                            .ReverseMap();
            CreateMap<TourDTO, Tour>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<TicketDTO, TicketLowInfo>().ReverseMap();
            CreateMap<TourDTO, TourLowInfo>().ReverseMap();
            CreateMap<UserDTO, UserLowInfo>().ReverseMap();

            CreateMap<MediaDTO, Media>().ReverseMap();

            CreateMap<Page, PageDTO>();
        }
    }
}
