using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Account_InfoResponse
    {
        [JsonPropertyName("info")]
        public AccountInfo Info { get; set; }
    }
}
