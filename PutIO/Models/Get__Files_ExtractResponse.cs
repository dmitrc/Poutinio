using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Files_ExtractResponse
    {
        [JsonPropertyName("extractions")]
        public Extraction[] Extractions { get; set; }
    }
}
