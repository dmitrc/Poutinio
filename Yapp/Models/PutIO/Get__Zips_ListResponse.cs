using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yapp.Models
{
    public class Get__Zips_ListResponse
    {
        [JsonPropertyName("zips")]
        public Get__Zips_ListResponse_Zips[] Zips { get; set; }
    }
}
