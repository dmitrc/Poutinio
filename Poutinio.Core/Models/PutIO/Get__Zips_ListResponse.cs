using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Poutinio.Core.Models
{
    public class Get__Zips_ListResponse
    {
        [JsonPropertyName("zips")]
        public Get__Zips_ListResponse_Zips[] Zips { get; set; }
    }
}
