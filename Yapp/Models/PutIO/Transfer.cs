using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Transfer
    {
        [JsonPropertyName("availability")]
        public int Availability { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("current_ratio")]
        public float CurrentRatio { get; set; }

        [JsonPropertyName("downloaded")]
        public int Downloaded { get; set; }

        [JsonPropertyName("uploaded")]
        public int Uploaded { get; set; }

        [JsonPropertyName("down_speed")]
        public int DownSpeed { get; set; }

        [JsonPropertyName("up_speed")]
        public int UpSpeed { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("estimated_time")]
        public int EstimatedTime { get; set; }

        [JsonPropertyName("file_id")]
        public int FileId { get; set; }

        [JsonPropertyName("finished_at")]
        public DateTime FinishedAt { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("peers")]
        public int Peers { get; set; }

        [JsonPropertyName("percent_done")]
        public int PercentDone { get; set; }

        [JsonPropertyName("save_parent_id")]
        public int SaveParentId { get; set; }

        [JsonPropertyName("seconds_seeding")]
        public int SecondsSeeding { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("subscription_id")]
        public int SubscriptionId { get; set; }

        [JsonPropertyName("tracker_message")]
        public string TrackerMessage { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
