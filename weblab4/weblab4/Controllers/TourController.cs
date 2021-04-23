using BLL.Abstractions.DTO;
using BLL.Abstractions.DTO.Page;
using BLL.Abstractions.Services;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weblab4.Controllers
{
    [ApiController]
    [Route("tour")]
    public class TourController : Controller
    {
        private readonly ILogger<TourController> _logger;
        private readonly ITourService _toursService;

        public TourController(ILogger<TourController> logger, ITourService tourService)
        {
            _logger = logger;
            this._toursService = tourService;
        }

        [HttpGet]
        public async Task<IEnumerable<TourDTO>> Get(PageDTO page)
        {
            return await _toursService.GetToursAsync(page);
        }

        [HttpGet("{id}")]
        public async Task<TourDTO> GetById(int id)
        {
            return await _toursService.GetTourAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] TourDTO tour)
        {
            tour.TourId = 0;
            var id = await _toursService.CreateTourAsync(tour);
            return Created($"{Request.Path.Value}/{id}", id);
        }

        [HttpPut]
        public async Task Update([FromBody] TourDTO tour)
        {
            await _toursService.UpdateTourAsync(tour);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _toursService.DeleteTourAsync(id);
        }
    }
}
