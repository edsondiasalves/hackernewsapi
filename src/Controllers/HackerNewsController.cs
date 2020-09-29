using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace hackernewsapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly ILogger<HackerNewsController> _logger;
        private const string BEST_STORIES_URL = "Https://hacker-news.firebaseio.com/v0/beststories.json";
        private const string STORY_DETAIL_URL = "https://hacker-news.firebaseio.com/v0/item/";

        public HackerNewsController(ILogger<HackerNewsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Story>> Get()
        {
            var stories = new List<Story>();

            using (var client = new HttpClient()){            
                var responseBestStories = await client.GetStringAsync(BEST_STORIES_URL);
                var bestStories = JsonSerializer.Deserialize<int[]>(responseBestStories);

                Array.Sort(bestStories);
                
                var tasks = bestStories.Select(async currentStory =>
                {
                    var url = $"{STORY_DETAIL_URL}{currentStory}.json";
                    await client.GetStringAsync(url).ContinueWith(response =>
                    {
                        Story story = JsonSerializer.Deserialize<Story>(response.Result);
                        stories.Add(story);
                    });
                }).ToList();

                Task.WaitAll(tasks.ToArray());
            }

            return stories.OrderByDescending(s => s.score).Take(20);
        }
    }
}
