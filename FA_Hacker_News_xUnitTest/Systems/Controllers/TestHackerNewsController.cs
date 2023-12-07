using FA_Hacker_News_API.Controllers;
using FA_Hacker_News_API.Implementation;
using FA_Hacker_News_API.Interface;
using FA_Hacker_News_API.Models;
using FA_Hacker_News_xUnitTest.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FA_Hacker_News_xUnitTest.Systems.Controllers
{
    public class TestHackerNewsController
    {
        private HackerNewsController _newsController;
        private Mock<IHackerNewsService> _hackerService;

        /// <summary>
        /// Test case for HackerNewsController
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetHackerNewsAsync_ShouldReturn200Status()
        {
            ///Arrange
            var mockHttpContext = new Mock<HttpContext>();
            _hackerService = new Mock<IHackerNewsService>();

            _hackerService.Setup(x => x.GetHackerNewsListAsync()).ReturnsAsync(HackerNewsMockData.GetHackerNews());

            _newsController = new HackerNewsController(_hackerService.Object);
            _newsController.ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext.Object
            };

            ///Act
            var result = await _newsController.GetHackerNewsAsync();

            ///Assert
            Assert.NotNull(result);
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetHackerNewsAsync_ShouldReturn204Status()
        {
            ///Arrange
            var mockHttpContext = new Mock<HttpContext>();
            _hackerService = new Mock<IHackerNewsService>();
            _hackerService.Setup(x => x.GetHackerNewsListAsync()).ReturnsAsync(HackerNewsMockData.GetEmptyHackerNews());

            _newsController = new HackerNewsController(_hackerService.Object);
            _newsController.ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext.Object
            };

            ///Act
            var result = await _newsController.GetHackerNewsAsync();

            ///Assert
            Assert.NotNull(result);
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }        
    }
}
