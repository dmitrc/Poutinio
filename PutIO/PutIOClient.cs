using System;
using System.Net.Http;
using Refit;
using PutIO.Apis;

namespace PutIO
{
    public class PutIOClient
    {
        public PutIOClient(HttpClient http)
        {
            AccountApi = RestService.For<IAccountApi>(http);
            TransfersApi = RestService.For<ITransfersApi>(http);
            FilesApi = RestService.For<IFilesApi>(http);
            SharesApi = RestService.For<ISharesApi>(http);
            EventsApi = RestService.For<IEventsApi>(http);
            ConfigApi = RestService.For<IConfigApi>(http);
            ZipsApi = RestService.For<IZipsApi>(http);
            RssApi = RestService.For<IRssApi>(http);
            FriendsApi = RestService.For<IFriendsApi>(http);
            OobApi = RestService.For<IOobApi>(http);
        }

        public IAccountApi AccountApi { get; }
        public ITransfersApi TransfersApi { get; }
        public IFilesApi FilesApi { get; }
        public ISharesApi SharesApi { get; }
        public IEventsApi EventsApi { get; }
        public IConfigApi ConfigApi { get; }
        public IZipsApi ZipsApi { get; }
        public IRssApi RssApi { get; }
        public IFriendsApi FriendsApi { get; }
        public IOobApi OobApi { get; }
    }
}
