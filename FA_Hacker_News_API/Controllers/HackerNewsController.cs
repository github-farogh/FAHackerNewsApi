using FA_Hacker_News_API.Implementation;
using FA_Hacker_News_API.Interface;
using FA_Hacker_News_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA_Hacker_News_API.Controllers
{
    [Route("hackernews")]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNews;

        public HackerNewsController(IHackerNewsService hackerNews)
        {
            _hackerNews = hackerNews;
        }

        /// <summary>
        /// To get Hacker News from api
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<IActionResult> GetHackerNewsAsync()
        {
            try
            {
                var hackerListModel = await _hackerNews.GetHackerNewsListAsync();

                if (hackerListModel.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(hackerListModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}