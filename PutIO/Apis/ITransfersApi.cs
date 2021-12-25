using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface ITransfersApi
    {
        [Get("/transfers/list")]
        Task<Get__Transfers_ListResponse> Get__Transfers_List();

        [Get("/transfers/{id}")]
        Task<Get__TransfersResponse> Get__Transfers(int id);

        [Multipart]
        [Post("/transfers/add")]
        Task<Post__Transfers_AddResponse> Post__Transfers_Add(string url, [AliasAs("save_parent_id")] int saveParentId, [AliasAs("callback_url")] string callbackUrl);

        [Post("/transfers/retry")]
        Task<Post__Transfers_RetryResponse> Post__Transfers_Retry([Query] int id);

        [Multipart]
        [Post("/transfers/cancel")]
        Task Post__Transfers_Cancel([AliasAs("transfer_ids")] int[] transferIds);

        [Multipart]
        [Post("/transfers/clean")]
        Task<Post__Transfers_CleanResponse> Post__Transfers_Clean([AliasAs("transfer_ids")] int[] transferIds);

        [Multipart]
        [Post("/transfers/remove")]
        Task Post__Transfers_Remove([AliasAs("remove_filter")] string removeFilter, [AliasAs("transfer_ids")] int[] transferIds);
    }
}
