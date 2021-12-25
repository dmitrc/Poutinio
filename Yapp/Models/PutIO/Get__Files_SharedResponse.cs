using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__Files_SharedResponse
    {
        [JsonPropertyName("shared")]
        public Get__Files_SharedResponse_Shared[] Shared { get; set; }
    }
}
