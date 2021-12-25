using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class File
    {
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }

        [JsonPropertyName("crc32")]
        public string Property_Crc32 { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_mp4_available")]
        public bool Property_IsMp4Available { get; set; }

        [JsonPropertyName("is_shared")]
        public bool IsShared { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        [JsonPropertyName("screenshot")]
        public string Screenshot { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("file_type")]
        public string FileType { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("need_convert")]
        public bool NeedConvert { get; set; }

        [JsonPropertyName("mp4_size")]
        public int Property_Mp4Size { get; set; }
    }
}
