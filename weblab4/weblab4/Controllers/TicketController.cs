using AutoMapper;
using BLL.Abstractions;
using BLL.Abstractions.DTO;
using BLL.Abstractions.DTO.Page;
using BLL.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weblab4.Controllers
{
    [ApiController]
    [Route("ticket")]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _ticketService;

        public TicketController(ILogger<TicketController> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketDTO>> Get(PageDTO page)
        {
            return await _ticketService.GetTicketsAsync(page);
        }

        [HttpGet("{id}")]
        public async Task<TicketDTO> GetById(int id)
        {
            return await _ticketService.GetTicketAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] TicketDTO ticket)
        {
            ticket.TicketId = 0;
            var id = await _ticketService.CreateTicketAsync(ticket);
            return Created($"{Request.Path.Value}/{id}", id);
        }

        [HttpPut]
        public async Task Update([FromBody] TicketDTO ticket)
        {
            await _ticketService.UpdateTicketAsync(ticket);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
        }
    }
}
