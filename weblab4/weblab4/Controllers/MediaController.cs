using BLL.Abstractions.DTO.Media;
using BLL.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using weblab4.Model;

namespace weblab4.Controllers
{
    [ApiController]
    [Route("media")]
    public class MediaController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly IMediaService _mediaService;

        public MediaController(ILogger<TicketController> logger, IMediaService ticketService)
        {
            _logger = logger;
            _mediaService = ticketService;
        }

        [HttpGet("{id}")]
        public async Task<MediaDTO> GetById(int id)
        {
            return await _mediaService.Get(id);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<int>> Upload([FromForm] CreateFileModel file)
        {
            var id = await _mediaService.Save(file?.FormFile);
            return Created($"{Request.Path.Value}/{id}", id);
        }

        [HttpGet("images")]
        public async Task<ActionResult> GetFromCloud(string path)
        {
            var loadPath = await _mediaService.GetCloudPath(path);

            using (var client = new WebClient())
            {
                var data = client.DownloadData(new Uri(loadPath));

                return File(data, "image/jpeg");
            }
        }
    }
}
