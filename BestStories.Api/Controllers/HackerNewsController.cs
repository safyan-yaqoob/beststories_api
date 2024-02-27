using BestStories.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestStories.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly HackerNewsService _hackerNewsService;

        public HackerNewsController(HackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        /// <summary>
        /// Get best stories from hacker new api
        /// </summary>
        /// <param name="numberOfStories"></param>
        /// <returns></returns>
        [HttpGet("best-stories/{numberOfStories}")]
        public async Task<IActionResult> GetBestStories(int numberOfStories)
        {
            var bestStoriesResponse = await _hackerNewsService.GetBestStoriesAsync(numberOfStories);
            return Ok(bestStoriesResponse);
        }
    }
}
