using System.Collections.Generic;

namespace PivotalTrackerConnector.Models.Stories
{
    public class PivotalSearchStory
    {
        public IEnumerable<PivotalStory> Stories { get; set; }
        public int TotalHits { get; set; }
        public int TotalHitsWithDone { get; set; }
        public int TotalPoints { get; set; }
        public int TotalPointsCompleted{ get; set; }
    }
}
