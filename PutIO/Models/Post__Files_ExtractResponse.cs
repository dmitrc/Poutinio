using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Post__Files_ExtractResponse
    {
        [JsonPropertyName("extractions")]
        public Extraction[] Extractions { get; set; }
    }
}
