using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PivotalTrackerConnector.Models.Webhooks
{
    public partial class WebhookData
    {
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }

        [JsonProperty("guid", NullValueHandling = NullValueHandling.Ignore)]
        public string Guid { get; set; }

        [JsonProperty("project_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProjectVersion { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("highlight", NullValueHandling = NullValueHandling.Ignore)]
        public string Highlight { get; set; }

        [JsonProperty("changes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Change> Changes { get; set; }

        [JsonProperty("primary_resources", NullValueHandling = NullValueHandling.Ignore)]
        public List<PrimaryResource> PrimaryResources { get; set; }

        [JsonProperty("secondary_resources", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> SecondaryResources { get; set; }

        [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
        public PerformedBy Project { get; set; }

        [JsonProperty("performed_by", NullValueHandling = NullValueHandling.Ignore)]
        public PerformedBy PerformedBy { get; set; }

        [JsonProperty("occurred_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? OccurredAt { get; set; }
    }
}
