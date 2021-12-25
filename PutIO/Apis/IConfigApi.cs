using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;

using PutIO.Models;

namespace PutIO.Apis
{
    public interface IConfigApi
    {
        [Get("/config")]
        Task<Config> Get__Config();

        [Put("/config")]
        Task Put__Config([Body] Config body);

        [Get("/config/{key}")]
        Task<ConfigValue> Get__ConfigValue(string key);

        [Put("/config/{key}")]
        Task Put__ConfigValue(string key, [Body] ConfigValue body);

        [Delete("/config/{key}")]
        Task Delete__ConfigValue(string key);
    }
}
