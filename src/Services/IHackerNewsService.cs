using System.Collections.Generic;
using System.Threading.Tasks;


namespace hackernewsapi.Services{
    public interface IHackerNewsService
    {
        Task<IEnumerable<Story>> GetBestOrderedStories();
    }
}