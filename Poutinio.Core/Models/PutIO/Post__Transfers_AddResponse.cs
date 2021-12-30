using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Post__Transfers_AddResponse
    {
        [JsonPropertyName("transfer")]
        public Transfer Transfer { get; set; }
    }
}
