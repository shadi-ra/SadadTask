using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sadad.Core.ApplicationService.Services.HttpClient;
using Sadad.Core.Entities.Model;


namespace SadadWebApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HttpClientController : ControllerBase
    {

        private static ILogger<HttpClientController> _logger;
        private readonly HttpClientUser client;
        public HttpClientController(HttpClientUser client, ILogger<HttpClientController> logger)
        {
            this.client = client;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Requested a HttpClientController");
            if (ModelState.IsValid)
            {
                var item = client.GetItem();
                return Ok(item);
            }
            return BadRequest();
        }

    }
}
