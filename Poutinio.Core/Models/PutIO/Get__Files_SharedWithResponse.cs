using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Files_SharedWithResponse
    {
        [JsonPropertyName("shared-with")]
        public Get__Files_SharedWithResponse_SharedWith[] SharedWith { get; set; }
    }
}
