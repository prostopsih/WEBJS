using BLL.Abstractions.Infrastructure;
using DAL.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public class Unit : IUnit
    {
        private readonly ITourRepository _tourRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMediaRepository _mediaRepository;

        public Unit(ITourRepository tourRepository, IUserRepository userRepository, ITicketRepository ticketRepository, IMediaRepository mediaRepository)
        {
            _tourRepository = tourRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _mediaRepository = mediaRepository;
        }

        public ITourRepository TourRepository => _tourRepository;
        public IUserRepository UserRepository => _userRepository;
        public ITicketRepository TicketRepository => _ticketRepository;
        public IMediaRepository MediaRepository => _mediaRepository;
    }
}
