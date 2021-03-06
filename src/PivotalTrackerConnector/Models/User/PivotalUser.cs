﻿using System.Collections.Generic;

namespace PivotalTrackerConnector.Models.User
{
    public class PivotalUser : PivotalModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Initials { get; set; }
        public string ApiToken { get; set; }
        public List<PivotalUserProject> Projects { get; set; }
    }
}
