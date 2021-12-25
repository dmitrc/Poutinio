using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IEventsApi
    {
        [Get("/events/list")]
        Task<Get__Events_ListResponse> Get__Events_List();

        [Post("/events/delete")]
        Task Post__Events_Delete();
    }
}
