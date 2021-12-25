using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class ConfigValue
    {
        [JsonPropertyName("value")]
        public object Value { get; set; }
    }
}
