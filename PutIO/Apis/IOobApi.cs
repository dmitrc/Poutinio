using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IOobApi
    {
        [Get("/oauth2/oob/code")]
        Task<OOBCode> Get__Oauth2_Oob_Code([Query] [AliasAs("app_id")] int appId, [Query] [AliasAs("client_name")] string clientName);

        [Get("/oauth2/oob/code/{code}")]
        Task<OAuthToken> Get__Oauth2_Oob_Code(string code);
    }
}
