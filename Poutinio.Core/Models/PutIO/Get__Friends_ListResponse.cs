using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Friends_ListResponse
    {
        [JsonPropertyName("friends")]
        public Friend[] Friends { get; set; }
    }
}
