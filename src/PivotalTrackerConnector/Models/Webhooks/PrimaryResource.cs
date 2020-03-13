using Newtonsoft.Json;

namespace PivotalTrackerConnector.Models.Webhooks
{
    public partial class PrimaryResource
    {
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }
    }
}
