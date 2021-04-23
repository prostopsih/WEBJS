using BLL.Abstractions.DTO;
using BLL.Abstractions.DTO.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions.Services
{
    public interface ITicketService
    {
        Task<TicketDTO> GetTicketAsync(int id);
        Task<IEnumerable<TicketDTO>> GetTicketsAsync(PageDTO page);
        Task<int> CreateTicketAsync(TicketDTO ticket);
        Task UpdateTicketAsync(TicketDTO ticket);
        Task DeleteTicketAsync(int id);
    }
}
