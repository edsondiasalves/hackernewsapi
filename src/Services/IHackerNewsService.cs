using System.Threading.Tasks;


namespace hackernewsapi.Services{
public interface IHackerNewsService
    {
        Task<int[]> GetBestStoryIds();
        Task<Story> GetStoryFromId(int storyId);
    }
}