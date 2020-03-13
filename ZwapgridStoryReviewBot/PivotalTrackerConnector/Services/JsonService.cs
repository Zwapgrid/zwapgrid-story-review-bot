using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PivotalTrackerConnector.Services
{
    public static class JsonService
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings();

        static JsonService()
        {
            JsonSerializerSettings.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            JsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }

        public static string SerializeObjectToJson<T>(T model)
        {
            var json = JsonConvert.SerializeObject(model, Formatting.Indented, JsonSerializerSettings);
            return json;
        }

        public static T SerializeJsonToObject<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
            return obj;
        }
    }

    internal class CamelCaseExceptDictionaryNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            JsonDictionaryContract contract = base.CreateDictionaryContract(objectType);

            contract.DictionaryKeyResolver = propertyName => propertyName;

            return contract;
        }
    }
}
