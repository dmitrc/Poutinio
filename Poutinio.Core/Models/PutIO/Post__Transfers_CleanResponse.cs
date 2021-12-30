using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Post__Transfers_CleanResponse
    {
        [JsonPropertyName("deleted_ids")]
        public int[] DeletedIds { get; set; }
    }
}
