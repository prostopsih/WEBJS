using AutoMapper;
using BLL.Abstractions.DTO;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Abstractions.Exceptions;
using BLL.Abstractions.DTO.Page;
using DAL.Abstractions.Models;
using BLL.Abstractions;
using BLL.Abstractions.Infrastructure;
using BLL.Abstractions.Services;

namespace BLL.Services
{
    public class TicketService : ServiceBase, ITicketService
    {
        private readonly IUnit _unit;
        private readonly IMapper _mapper;

        public TicketService(IUnit unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<TicketDTO> GetTicketAsync(int id)
        {
            var ticket = await _unit.TicketRepository.GetAsync(id);

            ValidateEntity(ticket);

            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsAsync(PageDTO page)
        {
            var tickets = await _unit.TicketRepository.GetAllAsync(_mapper.Map<Page>(page));
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<int> CreateTicketAsync(TicketDTO ticket)
        {
            var ticketToAdd = _mapper.Map<Ticket>(ticket);
            var resId = await _unit.TicketRepository.CreateAsync(ticketToAdd);

            if ((resId ?? 0) == 0)
                throw new OperationCanceledException();

            return resId.Value;
        }

        public async Task UpdateTicketAsync(TicketDTO ticket)
        {
            var ticketToUpdate = _mapper.Map<Ticket>(ticket);
            await _unit.TicketRepository.UpdateAsync(ticketToUpdate);
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticketToDel = await _unit.TicketRepository.GetAsync(id);

            ValidateEntity(ticketToDel);

            await _unit.TicketRepository.DeleteAsync(ticketToDel);
        }
    }
}
