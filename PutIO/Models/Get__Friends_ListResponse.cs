using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Friends_ListResponse
    {
        [JsonPropertyName("friends")]
        public Friend[] Friends { get; set; }
    }
}
