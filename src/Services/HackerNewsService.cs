using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using hackernewsapi.Services.Api;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using hackernewsapi.Model;
using AutoMapper;

namespace hackernewsapi.Services{
    public class HackerNewsService : IHackerNewsService
    {
        private IHackerNewsApi _hackerNewsApi;
        private IMapper _mapper;
        public HackerNewsService([FromServices]IHackerNewsApi hackerNewsApi, IMapper mapper){
            _hackerNewsApi = hackerNewsApi;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OutputStory>> GetBestOrderedStories()
        {
            var outputStories = new List<OutputStory>();

            using (var client = new HttpClient()){            
                var bestStories = await _hackerNewsApi.GetBestStories();
                var stories = new List<Story>();
                
                Array.Sort(bestStories);

                var tasks = bestStories.Select(async storyId =>
                {
                    Story story = await _hackerNewsApi.GetStoryById(storyId);
                    stories.Add(story);
                }).ToList();

                Task.WaitAll(tasks.ToArray());

                outputStories = _mapper.Map<List<OutputStory>>(stories);
            }

            return outputStories.OrderByDescending(s => s.score).Take(20);
        }
    }

}