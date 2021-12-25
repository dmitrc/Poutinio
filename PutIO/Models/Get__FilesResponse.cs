using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class Get__FilesResponse
    {
        [JsonPropertyName("file")]
        public File File { get; set; }
    }
}
