using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Post__Files_Search_ContinueResponse
    {
        [JsonPropertyName("files")]
        public File[] Files { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}
