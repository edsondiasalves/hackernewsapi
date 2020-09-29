using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using hackernewsapi.Services.Api;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace hackernewsapi.Services{
    public class HackerNewsService : IHackerNewsService
    {
        private IHackerNewsApi _hackerNewsApi;
        public HackerNewsService([FromServices]IHackerNewsApi hackerNewsApi){
            _hackerNewsApi = hackerNewsApi;
        }

        public async Task<IEnumerable<Story>> GetBestOrderedStories()
        {
            var stories = new List<Story>();

            using (var client = new HttpClient()){            
                var bestStories = await _hackerNewsApi.GetBestStories();
                Array.Sort(bestStories);

                var tasks = bestStories.Select(async storyId =>
                {
                    Story story = await _hackerNewsApi.GetStoryById(storyId);
                    stories.Add(story);
                }).ToList();

                Task.WaitAll(tasks.ToArray());
            }

            return stories.OrderByDescending(s => s.score).Take(20);
        }
    }

}