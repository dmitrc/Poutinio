using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__Rss_ListResponse
    {
        [JsonPropertyName("feeds")]
        public RssFeed[] Feeds { get; set; }
    }
}
