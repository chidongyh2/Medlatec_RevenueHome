using CMS_Core.Models;
using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Common
{
    public class HttpClientService
    {
        private HttpClient Client { get; }
        private string _authorityUrls;
        private readonly ApiServiceInfo _apiServiceInfo;
        private ObjectCache _cache = MemoryCache.Default;
        public HttpClientService(string token = null, string authorityUrl = null, string clientId = null, string clientSecret = null, string scopes = null)
        {
            _authorityUrls = authorityUrl ?? ConfigurationSettings.AppSettings["AUTHORITY_LOCATION"];
            _apiServiceInfo = new ApiServiceInfo(clientId ?? ConfigurationSettings.AppSettings["CLIENT_ID_LOCATION"],
                clientSecret ?? ConfigurationSettings.AppSettings["CLIENT_SECRET_LOCATION"], scopes ?? ConfigurationSettings.AppSettings["SCOPES_LOCATION"]);
            Client = Task.Run(() =>
            {
                return GetClient(token);
            }).Result;
        }

        async Task<HttpClient> GetClient(string token = null)
        {
            var client = new HttpClient();

            if (!string.IsNullOrEmpty(token))
            {
                client.SetBearerToken(token);
            }
            else
            {
                token = await GetToken();
                client.SetBearerToken(token);
            }
            return client;
        }

        private async Task<string> GetToken()
        {
            try
            {
                if (string.IsNullOrEmpty(_authorityUrls))
                    return null;

                var disco = await DiscoveryClient.GetAsync(_authorityUrls);
                if (disco.IsError)
                    return null;
                if (string.IsNullOrEmpty(_apiServiceInfo.ClientId) || string.IsNullOrEmpty(_apiServiceInfo.ClientSecret) || string.IsNullOrEmpty(_apiServiceInfo.Scopes))
                    return null;

                var tokenClient = new TokenClient(disco.TokenEndpoint, _apiServiceInfo.ClientId, _apiServiceInfo.ClientSecret);
                var tokenResponse = await tokenClient.RequestClientCredentialsAsync(_apiServiceInfo.Scopes);
                if (tokenResponse.IsError)
                    return null;
                var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromDays(1) };
                _cache.Add(new CacheItem("LOCATION_ACCESS_TOKEN", tokenResponse.AccessToken), policy);
                return tokenResponse.AccessToken;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            if (Client == null)
                return default(T);

            var response = await Client.GetAsync(requestUri);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await GetClient();
                var refreshResponse = await Client.GetAsync(requestUri);
                return !refreshResponse.IsSuccessStatusCode ? default(T) : ParseResponse<T>(await refreshResponse.Content.ReadAsStringAsync());
            }

            return !response.IsSuccessStatusCode ? default(T) : ParseResponse<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> PostAsync<T>(string requestUri, Dictionary<string, string> paramters = null)
        {
            if (Client == null)
                return default(T);

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var encodedContent = new FormUrlEncodedContent(paramters);
            var response = await Client.PostAsync(requestUri, encodedContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await GetClient();
                var refreshResponse = await Client.PostAsync(requestUri, encodedContent);
                return !refreshResponse.IsSuccessStatusCode ? default(T) : ParseResponse<T>(await refreshResponse.Content.ReadAsStringAsync());
            }
            return !response.IsSuccessStatusCode ? default(T) : ParseResponse<T>(await response.Content.ReadAsStringAsync());
        }

        private static T ParseResponse<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
