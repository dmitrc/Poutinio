using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Files_StartFromResponse
    {
        [JsonPropertyName("start_from")]
        public int StartFrom { get; set; }
    }
}
