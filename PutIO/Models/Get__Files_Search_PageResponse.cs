using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Files_Search_PageResponse
    {
        [JsonPropertyName("files")]
        public File[] Files { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }
    }
}
