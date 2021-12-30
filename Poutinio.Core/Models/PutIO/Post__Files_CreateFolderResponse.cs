using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Post__Files_CreateFolderResponse
    {
        [JsonPropertyName("file")]
        public File File { get; set; }
    }
}
