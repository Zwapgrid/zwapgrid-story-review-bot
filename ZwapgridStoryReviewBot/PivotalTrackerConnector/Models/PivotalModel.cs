using System;

namespace PivotalTrackerConnector.Models
{
    public class PivotalModel
    {
        //public int Id { get; set; }
        public string Kind { get; set; }

        // public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        // public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
