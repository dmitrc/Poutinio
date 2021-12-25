using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__Files_Mp4Response
    {
        [JsonPropertyName("mp4")]
        public Get__Files_Mp4Response_Property_Mp4 Property_Mp4 { get; set; }
    }
}
