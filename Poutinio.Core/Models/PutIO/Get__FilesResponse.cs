using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__FilesResponse
    {
        [JsonPropertyName("file")]
        public File File { get; set; }
    }
}
