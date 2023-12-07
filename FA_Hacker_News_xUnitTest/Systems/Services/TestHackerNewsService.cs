using FA_Hacker_News_API.Controllers;
using FA_Hacker_News_API.Implementation;
using FA_Hacker_News_API.Interface;
using FA_Hacker_News_API.Models;
using FA_Hacker_News_xUnitTest.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace FA_Hacker_News_xUnitTest.Systems.Services
{

    public class TestHackerNewsService
    {
        private Mock<IConfiguration> _configuration;
        private Mock<IHackerNewsService> _hackerNewsService;
        private Mock<ICacheService> _cacheService;

        /// <summary>
        /// Test case for HackerNewsService
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetHackerNewsAsync_ReturnNewsList()
        {
            ///Arrange
            _hackerNewsService = new Mock<IHackerNewsService>();
            _configuration = new Mock<IConfiguration>();
            _cacheService = new Mock<ICacheService>();

            _hackerNewsService.Setup(x => x.GetHackerNewsListAsync()).ReturnsAsync(HackerNewsMockData.GetHackerNews());

            var sysTest = new HackerNewsService(_configuration.Object, _cacheService.Object); 

            ///Act
            var result = await _hackerNewsService.Object.GetHackerNewsListAsync();
            
            ///Asserts
            result.Should().NotBeNull();
            result.Should().HaveCount(HackerNewsMockData.GetHackerNews().Count);            
        }
    }
}
