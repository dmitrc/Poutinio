using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Files_Mp4Response_Property_Mp4
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("percent_done")]
        public int PercentDone { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
