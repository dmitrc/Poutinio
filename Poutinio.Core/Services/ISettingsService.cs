using System;
using System.Diagnostics.Contracts;

namespace Poutinio.Core.Services
{
    public interface ISettingsService
    {
        void SetValue<T>(string key, T value);

        [Pure]
        T? GetValue<T>(string key);

        void SetToken(string value);

        string GetToken();

        bool HasToken();
    }
}
