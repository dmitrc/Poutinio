using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__Files_SharedWithResponse_SharedWith
    {
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("user_avatar_url")]
        public string UserAvatarUrl { get; set; }

        [JsonPropertyName("share_id")]
        public int ShareId { get; set; }
    }
}
