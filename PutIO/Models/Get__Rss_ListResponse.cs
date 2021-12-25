using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Rss_ListResponse
    {
        [JsonPropertyName("feeds")]
        public RssFeed[] Feeds { get; set; }
    }
}
