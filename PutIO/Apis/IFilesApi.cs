using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IFilesApi
    {
        [Get("/files/list")]
        Task<Get__Files_ListResponse> Get__Files_List([Query] [AliasAs("parent_id")] int? parentId, [Query] [AliasAs("per_page")] int? perPage, [Query] [AliasAs("sort_by")] string sortBy, [Query] [AliasAs("content_type")] string contentType, [Query] [AliasAs("file_type")] string[] fileType, [Query] [AliasAs("stream_url")] bool? streamUrl, [Query] [AliasAs("stream_url_parent")] bool? streamUrlParent, [Query] [AliasAs("mp4_stream_url")] bool? mp4StreamUrl, [Query] [AliasAs("mp4_stream_url_parent")] bool? mp4StreamUrlParent, [Query] bool? hidden, [Query] [AliasAs("mp4_status")] bool? mp4Status);

        [Multipart]
        [Post("/files/list/continue")]
        Task<Post__Files_List_ContinueResponse> Post__Files_List_Continue(string cursor, [AliasAs("per_page")] int perPage);

        [Get("/files/search")]
        Task<Get__Files_SearchResponse> Get__Files_Search([Query] string query, [Query] [AliasAs("per_page")] int? perPage);

        [Multipart]
        [Post("/files/search/continue")]
        Task<Post__Files_Search_ContinueResponse> Post__Files_Search_Continue(string cursor, [AliasAs("per_page")] int perPage);

        [Multipart]
        [Post("/files/create-folder")]
        Task<Post__Files_CreateFolderResponse> Post__Files_CreateFolder(string name, [AliasAs("parent_id")] int parentId);

        [Multipart]
        [Post("/files/rename")]
        Task Post__Files_Rename([AliasAs("file_id")] int fileId, string name);

        [Multipart]
        [Post("/files/move")]
        Task Post__Files_Move([AliasAs("file_ids")] int[] fileIds, [AliasAs("parent_id")] int parentId);

        [Post("/files/{id}/mp4")]
        Task Post__Files_Mp4(int id);

        [Get("/files/{id}/mp4")]
        Task<Get__Files_Mp4Response> Get__Files_Mp4(int id);

        [Get("/files/{id}/subtitles")]
        Task<Get__Files_SubtitlesResponse> Get__Files_Subtitles(int id);

        [Get("/files/{id}/subtitles/{key}")]
        Task<string> Get__Files_Subtitles(int id, string key, [Query] string format);

        [Get("/files/{id}/hls/media.m3u8")]
        Task<string> Get__Files_Hls_MediaM3u8(int id, [Query] [AliasAs("subtitle_key")] string subtitleKey);

        [Multipart]
        [Post("/files/delete")]
        Task Post__Files_Delete([AliasAs("file_ids")] int[] fileIds);

        [Multipart]
        [Post("/files/upload")]
        Task<object> Post__Files_Upload(StreamPart file, string filename, [AliasAs("parent_id")] int parentId);

        [Get("/files/{id}/url")]
        Task<Get__Files_UrlResponse> Get__Files_Url(int id);

        [Get("/files/extract")]
        Task<Get__Files_ExtractResponse> Get__Files_Extract();

        [Multipart]
        [Post("/files/extract")]
        Task<Post__Files_ExtractResponse> Post__Files_Extract([AliasAs("file_ids")] int[] fileIds, string password);

        [Get("/files/{id}/start-from")]
        Task<Get__Files_StartFromResponse> Get__Files_StartFrom(int id);

        [Multipart]
        [Post("/files/{id}/start-from")]
        Task Post__Files_StartFrom(int time, int id);

        [Post("/files/{id}/start-from/delete")]
        Task Post__Files_StartFrom_Delete(int id);

        [Obsolete]
        [Get("/files/search/{query}/page/{page}")]
        Task<Get__Files_Search_PageResponse> Get__Files_Search_Page(string query, int page);

        [Obsolete]
        [Get("/files/{id}")]
        Task<Get__FilesResponse> Get__Files(int id, [Query] bool? codecs, [Query] [AliasAs("media_info")] bool? mediaInfo);

        [Obsolete]
        [Get("/files/{id}/download")]
        Task Get__Files_Download(int id);
    }
}
