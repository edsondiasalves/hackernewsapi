using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using hackernewsapi.Services;

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
            var stories = new List<Story>();

            using (var client = new HttpClient()){            
                var bestStories = await _hackerNewsService.GetBestStoryIds();
                Array.Sort(bestStories);
                
                var tasks = bestStories.Select(async currentStory =>
                {
                    Story story = await _hackerNewsService.GetStoryFromId(currentStory);
                    stories.Add(story);
                }).ToList();

                Task.WaitAll(tasks.ToArray());
            }

            return stories.OrderByDescending(s => s.score).Take(20);
        }
    }
}
