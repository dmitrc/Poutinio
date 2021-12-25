using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Post__Rss_CreateResponse
    {
        [JsonPropertyName("feed")]
        public RssFeed Feed { get; set; }
    }
}
