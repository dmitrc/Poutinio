using Windows.Foundation.Collections;
using Windows.Storage;

namespace Yapp.Services
{
    public sealed class SettingsService : ISettingsService
    {
        private readonly IPropertySet SettingsStorage = ApplicationData.Current.LocalSettings.Values;

        private readonly string TokenKey = "AuthToken";
        private string _cachedToken;

        public void SetValue<T>(string key, T value)
        {
            if (!SettingsStorage.ContainsKey(key))
            {
                SettingsStorage.Add(key, value);
            }
            else
            {
                SettingsStorage[key] = value;
            }
        }

        public T GetValue<T>(string key)
        {
            if (SettingsStorage.TryGetValue(key, out object value))
            {
                return (T)value;
            }

            return default;
        }

        public void SetToken(string token)
        {
            SetValue(TokenKey, token);
            _cachedToken = token;
        }

        public string GetToken()
        {
            if (string.IsNullOrEmpty(_cachedToken))
            {
                _cachedToken = GetValue<string>(TokenKey);
            }

            return _cachedToken;
        }

        public bool HasToken()
        {
            return !string.IsNullOrEmpty(GetToken());
        }
    }
}
