using System;
using System.Threading.Tasks;
using Refit;

using Yapp.Models;

namespace Yapp.Services
{
    public interface IPutIoService
    {
        [Get("/account/info")]
        [Headers("Authorization: Bearer")]
        Task<Get__Account_InfoResponse> Get__Account_Info();

        [Get("/account/settings")]
        [Headers("Authorization: Bearer")]
        Task<AccountSettings> Get__Account_Settings();

        [Get("/config")]
        [Headers("Authorization: Bearer")]
        Task<Config> Get__Config();

        [Put("/config")]
        [Headers("Authorization: Bearer")]
        Task Put__Config([Body] Config body);

        [Get("/config/{key}")]
        [Headers("Authorization: Bearer")]
        Task<ConfigValue> Get__ConfigValue(string key);

        [Put("/config/{key}")]
        [Headers("Authorization: Bearer")]
        Task Put__ConfigValue(string key, [Body] ConfigValue body);

        [Delete("/config/{key}")]
        [Headers("Authorization: Bearer")]
        Task Delete__ConfigValue(string key);

        [Get("/events/list")]
        [Headers("Authorization: Bearer")]
        Task<Get__Events_ListResponse> Get__Events_List();

        [Post("/events/delete")]
        [Headers("Authorization: Bearer")]
        Task Post__Events_Delete();

        [Get("/files/list")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_ListResponse> Get__Files_List([Query] [AliasAs("parent_id")] long? parentId = null, [Query] [AliasAs("per_page")] int? perPage = null, [Query] [AliasAs("sort_by")] string sortBy = null, [Query] [AliasAs("content_type")] string contentType = null, [Query] [AliasAs("file_type")] string[] fileType = null, [Query] [AliasAs("stream_url")] bool? streamUrl = null, [Query] [AliasAs("stream_url_parent")] bool? streamUrlParent = null, [Query] [AliasAs("mp4_stream_url")] bool? mp4StreamUrl = null, [Query] [AliasAs("mp4_stream_url_parent")] bool? mp4StreamUrlParent = null, [Query] bool? hidden = null, [Query] [AliasAs("mp4_status")] bool? mp4Status = null);

        [Multipart]
        [Post("/files/list/continue")]
        [Headers("Authorization: Bearer")]
        Task<Post__Files_List_ContinueResponse> Post__Files_List_Continue(string cursor, [AliasAs("per_page")] int? perPage = null);

        [Get("/files/search")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_SearchResponse> Get__Files_Search([Query] string query, [Query] [AliasAs("per_page")] int? perPage = null);

        [Multipart]
        [Post("/files/search/continue")]
        [Headers("Authorization: Bearer")]
        Task<Post__Files_Search_ContinueResponse> Post__Files_Search_Continue(string cursor, [AliasAs("per_page")] int? perPage = null);

        [Multipart]
        [Post("/files/create-folder")]
        [Headers("Authorization: Bearer")]
        Task<Post__Files_CreateFolderResponse> Post__Files_CreateFolder(string name, [AliasAs("parent_id")] long parentId);

        [Multipart]
        [Post("/files/rename")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_Rename([AliasAs("file_id")] long fileId, string name);

        [Multipart]
        [Post("/files/move")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_Move([AliasAs("file_ids")] long[] fileIds, [AliasAs("parent_id")] long parentId);

        [Post("/files/{id}/mp4")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_Mp4(long id);

        [Get("/files/{id}/mp4")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_Mp4Response> Get__Files_Mp4(long id);

        [Get("/files/{id}/subtitles")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_SubtitlesResponse> Get__Files_Subtitles(long id);

        [Get("/files/{id}/subtitles/{key}")]
        [Headers("Authorization: Bearer")]
        Task<string> Get__Files_Subtitles(long id, string key, [Query] string format);

        [Get("/files/{id}/hls/media.m3u8")]
        [Headers("Authorization: Bearer")]
        Task<string> Get__Files_Hls_MediaM3u8(long id, [Query] [AliasAs("subtitle_key")] string subtitleKey = "all");

        [Multipart]
        [Post("/files/delete")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_Delete([AliasAs("file_ids")] int[] fileIds);

        [Multipart]
        [Post("/files/upload")]
        [Headers("Authorization: Bearer")]
        Task<object> Post__Files_Upload(StreamPart file, string filename = null, [AliasAs("parent_id")] long? parentId = null);

        [Get("/files/{id}/url")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_UrlResponse> Get__Files_Url(long id);

        [Get("/files/extract")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_ExtractResponse> Get__Files_Extract();

        [Multipart]
        [Post("/files/extract")]
        [Headers("Authorization: Bearer")]
        Task<Post__Files_ExtractResponse> Post__Files_Extract([AliasAs("file_ids")] long[] fileIds, string password = null);

        [Get("/files/{id}/start-from")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_StartFromResponse> Get__Files_StartFrom(long id);

        [Multipart]
        [Post("/files/{id}/start-from")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_StartFrom(int time, long id);

        [Post("/files/{id}/start-from/delete")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_StartFrom_Delete(long id);

        [Obsolete]
        [Get("/files/search/{query}/page/{page}")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_Search_PageResponse> Get__Files_Search_Page(string query, int page);

        [Obsolete]
        [Get("/files/{id}")]
        [Headers("Authorization: Bearer")]
        Task<Get__FilesResponse> Get__Files(long id, [Query] bool? codecs = null, [Query] [AliasAs("media_info")] bool? mediaInfo = null);

        [Obsolete]
        [Get("/files/{id}/download")]
        [Headers("Authorization: Bearer")]
        Task Get__Files_Download(long id);

        [Get("/friends/list")]
        [Headers("Authorization: Bearer")]
        Task<Get__Friends_ListResponse> Get__Friends_List();

        [Get("/friends/waiting-requests")]
        [Headers("Authorization: Bearer")]
        Task<Get__Friends_WaitingRequestsResponse> Get__Friends_WaitingRequests();

        [Post("/friends/{username}/request")]
        [Headers("Authorization: Bearer")]
        Task Post__Friends_Request(string username);

        [Post("/friends/{username}/approve")]
        [Headers("Authorization: Bearer")]
        Task Post__Friends_Approve(string username);

        [Post("/friends/{username}/deny")]
        [Headers("Authorization: Bearer")]
        Task Post__Friends_Deny(string username);

        [Post("/friends/{username}/unfriend")]
        [Headers("Authorization: Bearer")]
        Task Post__Friends_Unfriend(string username);

        [Get("/oauth2/oob/code")]
        Task<OOBCode> Get__Oauth2_Oob_Code([Query] [AliasAs("app_id")] int appId, [Query] [AliasAs("client_name")] string clientName = null);

        [Get("/oauth2/oob/code/{code}")]
        Task<OAuthToken> Get__Oauth2_Oob_Code(string code);

        [Get("/rss/list")]
        [Headers("Authorization: Bearer")]
        Task<Get__Rss_ListResponse> Get__Rss_List();

        [Get("/rss/{id}")]
        [Headers("Authorization: Bearer")]
        Task<Get__RssResponse> Get__Rss(long id);

        [Multipart]
        [Post("/rss/{id}")]
        [Headers("Authorization: Bearer")]
        Task<Post__RssResponse> Post__Rss(string title, [AliasAs("rss_source_url")] string rssSourceUrl, [AliasAs("parent_dir_id")] long parentDirId, [AliasAs("delete_old_files")] bool deleteOldFiles, [AliasAs("dont_process_whole_feed")] bool dontProcessWholeFeed, string keyword, [AliasAs("unwanted_keywords")] string unwantedKeywords, bool paused, long id);

        [Multipart]
        [Post("/rss/create")]
        [Headers("Authorization: Bearer")]
        Task<Post__Rss_CreateResponse> Post__Rss_Create(string title, [AliasAs("rss_source_url")] string rssSourceUrl, [AliasAs("parent_dir_id")] long parentDirId, [AliasAs("delete_old_files")] bool deleteOldFiles, [AliasAs("dont_process_whole_feed")] bool dontProcessWholeFeed, string keyword, [AliasAs("unwanted_keywords")] string unwantedKeywords, bool paused);

        [Post("/rss/{id}/pause")]
        [Headers("Authorization: Bearer")]
        Task Post__Rss_Pause(long id);

        [Post("/rss/{id}/resume")]
        [Headers("Authorization: Bearer")]
        Task Post__Rss_Resume(long id);

        [Post("/rss/{id}/delete")]
        [Headers("Authorization: Bearer")]
        Task Post__Rss_Delete(long id);

        [Multipart]
        [Post("/files/share")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_Share([AliasAs("file_ids")] int[] fileIds, string[] friends);

        [Get("/files/shared")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_SharedResponse> Get__Files_Shared();

        [Get("/files/{id}/shared-with")]
        [Headers("Authorization: Bearer")]
        Task<Get__Files_SharedWithResponse> Get__Files_SharedWith(long id);

        [Multipart]
        [Post("/files/unshare")]
        [Headers("Authorization: Bearer")]
        Task Post__Files_Unshare(object[] shares);

        [Get("/transfers/list")]
        [Headers("Authorization: Bearer")]
        Task<Get__Transfers_ListResponse> Get__Transfers_List();

        [Get("/transfers/{id}")]
        [Headers("Authorization: Bearer")]
        Task<Get__TransfersResponse> Get__Transfers(long id);

        [Multipart]
        [Post("/transfers/add")]
        [Headers("Authorization: Bearer")]
        Task<Post__Transfers_AddResponse> Post__Transfers_Add(string url, [AliasAs("save_parent_id")] int? saveParentId = null, [AliasAs("callback_url")] string callbackUrl = null);

        [Post("/transfers/retry")]
        [Headers("Authorization: Bearer")]
        Task<Post__Transfers_RetryResponse> Post__Transfers_Retry([Query] long id);

        [Multipart]
        [Post("/transfers/cancel")]
        [Headers("Authorization: Bearer")]
        Task Post__Transfers_Cancel([AliasAs("transfer_ids")] long[] transferIds);

        [Multipart]
        [Post("/transfers/clean")]
        [Headers("Authorization: Bearer")]
        Task<Post__Transfers_CleanResponse> Post__Transfers_Clean([AliasAs("transfer_ids")] long[] transferIds);

        [Multipart]
        [Post("/transfers/remove")]
        [Headers("Authorization: Bearer")]
        Task Post__Transfers_Remove([AliasAs("remove_filter")] string removeFilter, [AliasAs("transfer_ids")] long[] transferIds);

        [Multipart]
        [Post("/zips/create")]
        [Headers("Authorization: Bearer")]
        Task<Post__Zips_CreateResponse> Post__Zips_Create([AliasAs("file_ids")] long[] fileIds);

        [Get("/zips/list")]
        [Headers("Authorization: Bearer")]
        Task<Get__Zips_ListResponse> Get__Zips_List();

        [Get("/zips/{id}")]
        [Headers("Authorization: Bearer")]
        Task<Get__ZipsResponse> Get__Zips(long id);
    }
}