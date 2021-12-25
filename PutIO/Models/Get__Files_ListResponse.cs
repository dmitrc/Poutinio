using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Files_ListResponse
    {
        [JsonPropertyName("files")]
        public File[] Files { get; set; }

        [JsonPropertyName("parent")]
        public File Parent { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}
