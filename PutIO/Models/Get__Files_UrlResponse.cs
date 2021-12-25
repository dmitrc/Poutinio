using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Files_UrlResponse
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
