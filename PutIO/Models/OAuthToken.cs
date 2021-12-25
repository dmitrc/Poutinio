using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PutIO.Models
{
    public class OAuthToken
    {
        [JsonPropertyName("oauth_token")]
        public string OauthToken { get; set; }
    }
}
