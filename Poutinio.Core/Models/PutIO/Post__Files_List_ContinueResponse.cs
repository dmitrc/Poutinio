using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Post__Files_List_ContinueResponse
    {
        [JsonPropertyName("files")]
        public File[] Files { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}
