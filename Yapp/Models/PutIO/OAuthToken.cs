using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class OAuthToken
    {
        [JsonPropertyName("oauth_token")]
        public string OauthToken { get; set; }
    }
}
