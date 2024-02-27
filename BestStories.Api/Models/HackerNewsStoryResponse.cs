﻿namespace BestStories.Api.Models
{
    public class HackerNewsStoryResponse
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string PostedBy { get; set; }
        public DateTime? Time { get; set; }
        public int Score { get; set; }
        public int? CommentCount { get; set; }
    }
}
