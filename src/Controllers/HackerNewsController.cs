using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using hackernewsapi.Services;
using hackernewsapi.Services.Api;

namespace hackernewsapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly ILogger<HackerNewsController> _logger;
        private IHackerNewsService _hackerNewsService;
        public HackerNewsController(ILogger<HackerNewsController> logger, IHackerNewsService hackerNewsService){
            _hackerNewsService = hackerNewsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Story>> Get()
        {
            return await _hackerNewsService.GetBestOrderedStories();
        }
    }
}
