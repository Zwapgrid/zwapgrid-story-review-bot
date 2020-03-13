using System.Collections.Generic;
using Newtonsoft.Json;

namespace PivotalTrackerConnector.Models.Webhooks
{
    public partial class NewValues
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("width_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string WidthMode { get; set; }

        [JsonProperty("project_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProjectId { get; set; }

        [JsonProperty("person_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PersonId { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdatedAt { get; set; }

        [JsonProperty("favorite_epics", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> FavoriteEpics { get; set; }

        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }

        [JsonProperty("project_color", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectColor { get; set; }

        [JsonProperty("favorite", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Favorite { get; set; }

        [JsonProperty("wants_comment_notification_emails", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WantsCommentNotificationEmails { get; set; }

        [JsonProperty("will_receive_mention_notifications_or_emails", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WillReceiveMentionNotificationsOrEmails { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("initials", NullValueHandling = NullValueHandling.Ignore)]
        public string Initials { get; set; }
    }
}
