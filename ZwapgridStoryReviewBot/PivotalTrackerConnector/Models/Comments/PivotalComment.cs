using System.Collections.Generic;
using PivotalTrackerConnector.Models.Attachments;

namespace PivotalTrackerConnector.Models.Comments
{
    public class PivotalComment : PivotalModel
    {
        public int StoryId { get; set; }
        public int ProjectId { get; set; }
        public List<PivotalAttachment> FileAttachments { get; set; }
        public List<int> FileAttachmentIds { get; set; }
        public int? PersonId { get; set; }
        public int Id { get; set; }
        public string Text { get; set; }        
    }

}
