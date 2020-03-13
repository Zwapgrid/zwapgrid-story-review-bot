using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PivotalTrackerConnector.Services
{ 
    public class FakeHttpService : IHttpService
    {
        private string _apiToken;
        public string ApiToken => _apiToken;

        private readonly string _baseUrl = "http://fakehttpservice.fake/";
        private readonly HttpClient _httpClient = new HttpClient();

        public virtual void SetupHttpClient(string apiToken)
        {
            _apiToken = apiToken;
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-TrackerToken", _apiToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public virtual async Task<HttpResponseMessage> AuthorizeAsync(string username, string password)
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Calls a GET request on the specified path.
        /// </summary>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <returns>HttpResponseMessage</returns>
        public virtual async Task<HttpResponseMessage> GetAsync(string path)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);      
        }

        /// <summary>
        /// Calls a POST request on the specified path, posting the model data as JSON.
        /// </summary>
        /// <typeparam name="T">Type to return deserialised JSON as.</typeparam>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <param name="data">Model data to be serialised as JSON.</param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PostAsync<T>(string path, T data)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Calls a POST request on the specified path, posting the model data as JSON.
        /// </summary>
        /// <typeparam name="T">Type to return deserialised JSON as.</typeparam>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <param name="data">Model data to be serialised as JSON.</param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PutAsync<T>(string path, T data)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Calls a POST request on the specified path, passing data as HttpContent.
        /// </summary>
        /// <typeparam name="T">Type to return deserialised JSON as.</typeparam>
        /// <param name="path">URL of the path to call as a string.</param>
        /// <param name="data">Data to be sent in the POST request as HttpContent</param>
        /// <param name="serialiseToJson">Whether or not to serialise as JSON. Calls <see cref="PostAsync{T}(string, T)"/> if true. Default: false.</param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PostContentAsync<T>(string path, T data, bool serialiseToJson = false) where T : HttpContent
        {
            if (serialiseToJson)
                return await PostAsync(path, data);


            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
