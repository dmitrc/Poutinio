using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface ISharesApi
    {
        [Multipart]
        [Post("/files/share")]
        Task Post__Files_Share([AliasAs("file_ids")] int[] fileIds, string[] friends);

        [Get("/files/shared")]
        Task<Get__Files_SharedResponse> Get__Files_Shared();

        [Get("/files/{id}/shared-with")]
        Task<Get__Files_SharedWithResponse> Get__Files_SharedWith(int id);

        [Multipart]
        [Post("/files/unshare")]
        Task Post__Files_Unshare(object[] shares);
    }
}
