using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Friends_WaitingRequestsResponse
    {
        [JsonPropertyName("friends")]
        public Friend[] Friends { get; set; }
    }
}
