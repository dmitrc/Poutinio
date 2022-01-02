using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Transfer
    {
        [JsonPropertyName("availability")]
        public int? Availability { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("current_ratio")]
        public float? CurrentRatio { get; set; }

        [JsonPropertyName("downloaded")]
        public long? Downloaded { get; set; }

        [JsonPropertyName("uploaded")]
        public long? Uploaded { get; set; }

        [JsonPropertyName("down_speed")]
        public int? DownSpeed { get; set; }

        [JsonPropertyName("up_speed")]
        public int? UpSpeed { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("estimated_time")]
        public long? EstimatedTime { get; set; }

        [JsonPropertyName("file_id")]
        public int? FileId { get; set; }

        [JsonPropertyName("finished_at")]
        public DateTime? FinishedAt { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("is_private")]
        public bool? IsPrivate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("peers_connected")]
        public int? PeersConnected { get; set; }

        [JsonPropertyName("percent_done")]
        public int? PercentDone { get; set; }

        [JsonPropertyName("save_parent_id")]
        public int? SaveParentId { get; set; }

        [JsonPropertyName("seconds_seeding")]
        public long? SecondsSeeding { get; set; }

        [JsonPropertyName("size")]
        public long? Size { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("subscription_id")]
        public int? SubscriptionId { get; set; }

        [JsonPropertyName("tracker_message")]
        public string TrackerMessage { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
