using FA_Hacker_News_API.Interface;
using FA_Hacker_News_API.Models;
using System.IO;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace FA_Hacker_News_API.Implementation
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;
        private readonly ICacheService _cacheService;
        public HackerNewsService(IConfiguration configuration, ICacheService cacheService) 
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _cacheService = cacheService;
        }

        /// <summary>
        /// Implemented get Hacker News dsata list from api
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HackerNewsModel>> GetHackerNewsListAsync()
        {
            var hackerListNews = new List<HackerNewsModel>();
            var url = _configuration.GetValue<string>("ApiUrl:hackerNewsApi");
            var cacheKey = _configuration.GetValue<string>("CacheKey:key");

            hackerListNews = _cacheService.GetCacheData<List<HackerNewsModel>>(cacheKey);

            if (hackerListNews != null)
            {
                return hackerListNews;
            }

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var ServiceResponse = response.Content.ReadAsStringAsync().Result;
                var hackerListIds = JsonConvert.DeserializeObject<List<int>>(ServiceResponse).Take(200);
                hackerListNews = new List<HackerNewsModel>();

                foreach (var item in hackerListIds)
                {
                    var hackerNewsData = await GetHackerNewsOnIdAsync(item);
                    if (hackerNewsData != null)
                    {
                        hackerListNews.Add(hackerNewsData);
                    }
                }
                var expirationTime = DateTimeOffset.Now.AddMinutes(30.0);
                _cacheService.SetCacheData<List<HackerNewsModel>>(cacheKey, hackerListNews, expirationTime);
            }
            return hackerListNews;
        }

        /// <summary>
        /// Private method to implement api get HackerNews on Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private async Task<HackerNewsModel> GetHackerNewsOnIdAsync(int Id)
        {
            var hackerDataModel = new HackerNewsModel();

            var url = _configuration.GetValue<string>("ApiUrl:hackerNewsOnIdApi");
            HttpResponseMessage ServiceResponse = await _httpClient.GetAsync(string.Format(url, Id));

            if (ServiceResponse.IsSuccessStatusCode)
            {
                var res = ServiceResponse.Content.ReadAsStringAsync().Result;
                hackerDataModel = JsonConvert.DeserializeObject<HackerNewsModel>(res);
            }
            return hackerDataModel;
        }        
    }
}
