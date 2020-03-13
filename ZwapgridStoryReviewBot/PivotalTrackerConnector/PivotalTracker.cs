namespace PivotalTrackerConnector
{
    public class PivotalTracker
    {
        public Services.PivotalTracker Tracker { get; set; }

        public PivotalTracker(string apiToken, int? projectId = null)
        {
            Tracker = new Services.PivotalTracker(apiToken, projectId);
        }
    }
}
