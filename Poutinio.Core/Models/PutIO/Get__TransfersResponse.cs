using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__TransfersResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Transfer { get; set; }
    }
}
