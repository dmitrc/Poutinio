using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IFriendsApi
    {
        [Get("/friends/list")]
        Task<Get__Friends_ListResponse> Get__Friends_List();

        [Get("/friends/waiting-requests")]
        Task<Get__Friends_WaitingRequestsResponse> Get__Friends_WaitingRequests();

        [Post("/friends/{username}/request")]
        Task Post__Friends_Request(string username);

        [Post("/friends/{username}/approve")]
        Task Post__Friends_Approve(string username);

        [Post("/friends/{username}/deny")]
        Task Post__Friends_Deny(string username);

        [Post("/friends/{username}/unfriend")]
        Task Post__Friends_Unfriend(string username);
    }
}
