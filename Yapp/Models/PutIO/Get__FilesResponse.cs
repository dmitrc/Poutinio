using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__FilesResponse
    {
        [JsonPropertyName("file")]
        public File File { get; set; }
    }
}
