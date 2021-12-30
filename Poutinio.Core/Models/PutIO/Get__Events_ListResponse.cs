using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Events_ListResponse
    {
        [JsonPropertyName("events")]
        public Get__Events_ListResponse_Events[] Events { get; set; }
    }
}
