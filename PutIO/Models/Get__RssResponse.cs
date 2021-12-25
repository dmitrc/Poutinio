using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__RssResponse
    {
        [JsonPropertyName("feed")]
        public RssFeed Feed { get; set; }
    }
}
