using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__ZipsResponse
    {
        [JsonPropertyName("zip_status")]
        public string ZipStatus { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("missing_files")]
        public Get__ZipsResponse_MissingFiles[] MissingFiles { get; set; }
    }
}
