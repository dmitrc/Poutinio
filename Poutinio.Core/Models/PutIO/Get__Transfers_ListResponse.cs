using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Transfers_ListResponse
    {
        [JsonPropertyName("transfers")]
        public Transfer[] Transfers { get; set; }
    }
}
