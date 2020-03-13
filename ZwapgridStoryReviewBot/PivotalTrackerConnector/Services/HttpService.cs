using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PivotalTrackerConnector.Exceptions;
using PivotalTrackerConnector.Utils;

namespace PivotalTrackerConnector.Services
{ 
    public class HttpService : IHttpService
    {
        private string _apiToken;
        public string ApiToken => _apiToken;

        private readonly string _baseUrl = "https://www.pivotaltracker.com/services/v5/";
        private readonly HttpClient _httpClient = new HttpClient();

        private StringContent CreateStringContent(string content)
        {
            return new StringContent(content, Encoding.UTF8, "application/json");
        }

        public void SetupHttpClient(string apiToken)
        {
            _apiToken = apiToken;
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-TrackerToken", _apiToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Authorizes the <see cref="_httpClient"/> to use basic credential auth and retrieves the API Token from the user for setup.
        /// </summary>
        /// <param name="username">Your username to authenticate with.</param>
        /// <param name="password">Your password to authenticate with.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> AuthorizeAsync(string username, string password)
        {
            using (var authClient = new HttpClient())
            {
                var authoriseRequest = new HttpRequestMessage
                {
                    RequestUri = new Uri(_baseUrl + StringUtil.PivotalCurrentUser())
                };
                authoriseRequest.Headers.Authorization = new AuthenticationHeaderValue("basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
                authoriseRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
   
                return await authClient.SendAsync(authoriseRequest);
            }
        }
        
        /// <summary>
        /// Calls a GET request on the specified path.
        /// </summary>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetAsync(string path)
        {
            CheckTokenExists();
            return _httpClient.GetAsync(path);
        }

        /// <summary>
        /// Calls a POST request on the specified path, posting the model data as JSON.
        /// </summary>
        /// <typeparam name="T">Type to return deserialised JSON as.</typeparam>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <param name="data">Model data to be serialised as JSON.</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PostAsync<T>(string path, T data)
        {
            CheckTokenExists();
            var content = CreateStringContent(JsonService.SerializeObjectToJson(data));
            return _httpClient.PostAsync(path, content);
        }

        /// <summary>
        /// Calls a POST request on the specified path, posting the model data as JSON.
        /// </summary>
        /// <typeparam name="T">Type to return deserialised JSON as.</typeparam>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <param name="data">Model data to be serialised as JSON.</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PutAsync<T>(string path, T data)
        {
            CheckTokenExists();
            var content = CreateStringContent(JsonService.SerializeObjectToJson(data));
            return _httpClient.PutAsync(path, content);
        }

        /// <summary>
        /// Calls a POST request on the specified path, passing data as HttpContent.
        /// </summary>
        /// <typeparam name="T">Type to return deserialised JSON as.</typeparam>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <param name="data">Data to be sent in the POST request as HttpContent</param>
        /// <param name="serialiseToJson">Whether or not to serialise as JSON. Calls <see cref="PostAsync{T}(string, T)"/> if true. Default: false.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostContentAsync<T>(string path, T data, bool serialiseToJson = false) where T : HttpContent
        {
            CheckTokenExists();
            if (serialiseToJson)
                return await PostAsync(path, data);

            return await _httpClient.PostAsync(path, data);
        }

        public Task<HttpResponseMessage> DeleteAsync(string path)
        {
            CheckTokenExists();
            return _httpClient.DeleteAsync(path);
        }
        
        /// <summary>
        /// Checks if the Api Token exists on the HttpService instance. Note: This is not required when calling the <see cref="AuthorizeAsync"/> method.
        /// </summary>
        /// <exception cref="PivotalAuthorisationException"></exception>
        private void CheckTokenExists()
        {
            if (string.IsNullOrEmpty(_apiToken))
                throw new PivotalAuthorisationException("Api Token has not been set. Please set it using HttpService.SetupHttpClient(string apiToken).");
        }
    }
}
