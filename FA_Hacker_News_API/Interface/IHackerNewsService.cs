using FA_Hacker_News_API.Models;

namespace FA_Hacker_News_API.Interface
{
    public interface IHackerNewsService
    {
        /// <summary>
        /// Interface method to get call
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HackerNewsModel>> GetHackerNewsListAsync();
    }
}
