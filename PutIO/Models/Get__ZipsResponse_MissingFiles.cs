using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__ZipsResponse_MissingFiles
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("missing")]
        public bool Missing { get; set; }
    }
}
