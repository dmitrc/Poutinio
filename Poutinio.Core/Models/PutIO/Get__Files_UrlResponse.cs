using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Files_UrlResponse
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}
