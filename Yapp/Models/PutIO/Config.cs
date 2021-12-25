using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Config
    {
        [JsonPropertyName("config")]
        public object ConfigProp { get; set; }
    }
}
