using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class OOBCode
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
