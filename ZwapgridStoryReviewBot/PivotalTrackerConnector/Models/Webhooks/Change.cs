using Newtonsoft.Json;

namespace PivotalTrackerConnector.Models.Webhooks
{
    public partial class Change
    {
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }

        [JsonProperty("change_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ChangeType { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("new_values", NullValueHandling = NullValueHandling.Ignore)]
        public NewValues NewValues { get; set; }
    }
}
