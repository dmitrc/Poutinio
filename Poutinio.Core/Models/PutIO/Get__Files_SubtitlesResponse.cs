using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Files_SubtitlesResponse
    {
        [JsonPropertyName("subtitles")]
        public Get__Files_SubtitlesResponse_Subtitles[] Subtitles { get; set; }
    }
}
