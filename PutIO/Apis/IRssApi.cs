using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IRssApi
    {
        [Get("/rss/list")]
        Task<Get__Rss_ListResponse> Get__Rss_List();

        [Get("/rss/{id}")]
        Task<Get__RssResponse> Get__Rss(int id);

        [Multipart]
        [Post("/rss/{id}")]
        Task<Post__RssResponse> Post__Rss(string title, [AliasAs("rss_source_url")] string rssSourceUrl, [AliasAs("parent_dir_id")] int parentDirId, [AliasAs("delete_old_files")] bool deleteOldFiles, [AliasAs("dont_process_whole_feed")] bool dontProcessWholeFeed, string keyword, [AliasAs("unwanted_keywords")] string unwantedKeywords, bool paused, int id);

        [Multipart]
        [Post("/rss/create")]
        Task<Post__Rss_CreateResponse> Post__Rss_Create(string title, [AliasAs("rss_source_url")] string rssSourceUrl, [AliasAs("parent_dir_id")] int parentDirId, [AliasAs("delete_old_files")] bool deleteOldFiles, [AliasAs("dont_process_whole_feed")] bool dontProcessWholeFeed, string keyword, [AliasAs("unwanted_keywords")] string unwantedKeywords, bool paused);

        [Post("/rss/{id}/pause")]
        Task Post__Rss_Pause(int id);

        [Post("/rss/{id}/resume")]
        Task Post__Rss_Resume(int id);

        [Post("/rss/{id}/delete")]
        Task Post__Rss_Delete(int id);
    }
}
