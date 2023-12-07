using FA_Hacker_News_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA_Hacker_News_xUnitTest.MockData
{
    public class HackerNewsMockData
    {
        public static List<HackerNewsModel> GetHackerNews()
        {
            return new List<HackerNewsModel>
            {
                new HackerNewsModel
                {
                    title = "HTML attributes for improved accessibility and user experience",
                    url = "https://www.htmhell.dev/adventcalendar/2023/4/",
                },
                new HackerNewsModel
                {
                    title = "Rob Pike: Gobs of data (2011)",
                    url = "https://go.dev/blog/gob",
                },
                new HackerNewsModel
                {
                    title = "Rob Pike: Gobs of data (2012)",
                    url = "https://go.dev/blog/gob",
                }
            };
        }

        public static List<HackerNewsModel> GetEmptyHackerNews()
        { 
            return new List<HackerNewsModel>();
        }
    }
}
