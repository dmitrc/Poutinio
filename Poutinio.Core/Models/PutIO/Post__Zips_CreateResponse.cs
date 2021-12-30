using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Post__Zips_CreateResponse
    {
        [JsonPropertyName("zip_id")]
        public int ZipId { get; set; }
    }
}
