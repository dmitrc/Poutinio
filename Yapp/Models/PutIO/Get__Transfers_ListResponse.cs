using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__Transfers_ListResponse
    {
        [JsonPropertyName("transfers")]
        public Transfer[] Transfers { get; set; }
    }
}
