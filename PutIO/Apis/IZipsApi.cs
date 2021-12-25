using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IZipsApi
    {
        [Multipart]
        [Post("/zips/create")]
        Task<Post__Zips_CreateResponse> Post__Zips_Create([AliasAs("file_ids")] int[] fileIds);

        [Get("/zips/list")]
        Task<Get__Zips_ListResponse> Get__Zips_List();

        [Get("/zips/{id}")]
        Task<Get__ZipsResponse> Get__Zips(int id);
    }
}
