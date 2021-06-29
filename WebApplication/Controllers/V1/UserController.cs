using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sadad.Core.ApplicationService.Dtos.UserDto;
using Sadad.Core.ApplicationService.Services.User;


namespace SadadWebApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private static ILogger<UserController> _logger;

        private IUserService userService;
        public UserController(IUserService userService,
            ILogger<UserController> logger)
        {
            _logger = logger;

            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Requested a UserController");
            if (ModelState.IsValid)
            {
                var item = await userService.GetAll();
                return Ok(item);
            }
            return BadRequest();

        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Requested a UserController");
            if (ModelState.IsValid)
            {
                var item = await userService.Get(id);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserInputDto input)
        {
            _logger.LogInformation("Requested a UserController");
            if (ModelState.IsValid)
            {
                var item = await userService.Create(input);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto input)
        {
            _logger.LogInformation("Requested a UserController");
            if (ModelState.IsValid)
            {               
                var item = await userService.Update(input);
                return Ok(item);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            _logger.LogInformation("Requested a UserController");
            if (ModelState.IsValid)
            {
                var item = await userService.Delete(id);
                return Ok(item);
            }
            return BadRequest();
        }
    

    }
}
