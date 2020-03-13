using Newtonsoft.Json;

namespace PivotalTrackerConnector.Models.Webhooks
{
    public partial class PerformedBy
    {
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("initials", NullValueHandling = NullValueHandling.Ignore)]
        public string Initials { get; set; }
    }
}
