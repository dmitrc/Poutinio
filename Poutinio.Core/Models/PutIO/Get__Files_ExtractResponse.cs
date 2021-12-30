using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Files_ExtractResponse
    {
        [JsonPropertyName("extractions")]
        public Extraction[] Extractions { get; set; }
    }
}
