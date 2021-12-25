using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IAccountApi
    {
        [Get("/account/info")]
        Task<Get__Account_InfoResponse> Get__Account_Info();

        [Get("/account/settings")]
        Task<AccountSettings> Get__Account_Settings();
    }
}
