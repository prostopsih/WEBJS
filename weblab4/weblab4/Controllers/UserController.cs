using BLL.Abstractions.DTO;
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
    [Route("user")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetById(int id)
        {
            return await _userService.GetUserAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] UserDTO user)
        {
            user.UserId = 0;
            var id = await _userService.CreateUserAsync(user);
            return Created($"{Request.Path.Value}/{id}", id);
        }

        [HttpPut]
        public async Task Update([FromBody] UserDTO user)
        {
            await _userService.UpdateUserAsync(user);
        }
    }
}
