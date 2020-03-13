namespace PivotalTrackerConnector.Models.Reviews
{
    public class Review : PivotalModel
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public int ReviewTypeId { get; set; }
        public int ReviewerId { get; set; }
        public string Status { get; set; }
    }
}