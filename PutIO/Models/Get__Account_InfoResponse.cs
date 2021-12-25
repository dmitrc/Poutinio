using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__Account_InfoResponse
    {
        [JsonPropertyName("info")]
        public AccountInfo Info { get; set; }
    }
}
