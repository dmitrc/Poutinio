using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class ConfigValue
    {
        [JsonPropertyName("value")]
        public object Value { get; set; }
    }
}
