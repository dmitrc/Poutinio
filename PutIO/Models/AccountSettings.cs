using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class AccountSettings
    {
        [JsonPropertyName("default_download_folder")]
        public int DefaultDownloadFolder { get; set; }

        [JsonPropertyName("is_invisible")]
        public bool IsInvisible { get; set; }

        [JsonPropertyName("subtitle_languages")]
        public string[] SubtitleLanguages { get; set; }

        [JsonPropertyName("default_subtitle_language")]
        public string DefaultSubtitleLanguage { get; set; }
    }
}
