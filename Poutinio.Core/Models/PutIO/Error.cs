using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Error
    {
        [JsonPropertyName("error_type")]
        public string ErrorType { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("error_id")]
        public string ErrorId { get; set; }

        [JsonPropertyName("extra")]
        public object Extra { get; set; }
    }
}
