using DAL.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstractions.Infrastructure
{
    public interface IUnit
    {
        ITourRepository TourRepository { get; }
        IUserRepository UserRepository { get; }
        ITicketRepository TicketRepository { get; }
        IMediaRepository MediaRepository { get; }
    }
}
