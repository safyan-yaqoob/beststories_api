﻿namespace BestStories.Api.Models
{
    public class HackerNewsStory
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string By { get; set; }
        public long Time { get; set; }
        public DateTime? PublishedTime => DateTimeOffset.FromUnixTimeSeconds(Time).UtcDateTime;
        public int Score { get; set; }
        public int Descendants { get; set; }
        public int? CommentCount => Descendants;
    }
}
