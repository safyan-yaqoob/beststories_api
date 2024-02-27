using BestStories.Api.Models;
using Microsoft.Extensions.Caching.Memory;
using Polly;

namespace BestStories.Api
{
    public class HackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        public HackerNewsService(HttpClient httpClient,
            IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }


        /// <summary>
        /// Get best n stories
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public async Task<List<HackerNewsStoryResponse>> GetBestStoriesAsync(int n)
        {
            var cacheKey = $"BestStories_{n}";

            if (!_cache.TryGetValue(cacheKey, out List<HackerNewsStory> bestStories))
            {
                var response = await _httpClient.GetFromJsonAsync<int[]>("beststories.json");
                var storyIds = response.Take(n).ToList();

                // When the Hacker News API experiences issues or becomes unavailable,
                // the polly circuit breaker opens and temporarily stops making requests,
                // preventing unnecessary load on the API and allowing it time to recover
                var policy = Policy.Handle<HttpRequestException>().CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

                bestStories = await policy.ExecuteAsync(async () =>
                {
                    var tasks = storyIds.Select(async id =>
                    {
                        var story = await _httpClient.GetFromJsonAsync<HackerNewsStory>($"item/{id}.json");
                        return story;
                    });

                    return (await Task.WhenAll(tasks)).ToList();
                });

                _cache.Set(cacheKey, bestStories, TimeSpan.FromMinutes(2));
            }

            return bestStories.OrderByDescending(s => s.Score).Select(e=> new HackerNewsStoryResponse
            {
                Title = e.Title,
                Time = e.PublishedTime,
                PostedBy = e.By,
                CommentCount = e.CommentCount,
                Score = e.Score,
                Url = e.Url
            }).ToList();
        }
    }
}
