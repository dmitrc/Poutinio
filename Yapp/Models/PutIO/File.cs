using System;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class File
    {
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }

        [JsonPropertyName("crc32")]
        public string Crc32 { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("is_mp4_available")]
        public bool IsMp4Available { get; set; }

        [JsonPropertyName("is_shared")]
        public bool IsShared { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        [JsonPropertyName("screenshot")]
        public string Screenshot { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("opensubtitles_hash")]
        public string OpenSubtitlesHash { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("file_type")]
        public string FileType { get; set; }

        [JsonPropertyName("folder_type")]
        public string FolderType { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("need_convert")]
        public bool? NeedConvert { get; set; }

        [JsonPropertyName("mp4_size")]
        public int? Mp4Size { get; set; }
    }
}
