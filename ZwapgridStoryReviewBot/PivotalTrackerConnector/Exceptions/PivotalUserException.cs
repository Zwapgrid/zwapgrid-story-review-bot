﻿namespace PivotalTrackerConnector.Exceptions
{
    public class PivotalUserException : PivotalException
    {
        public PivotalUserException() : base() { }
        public PivotalUserException(string message) : base(message) { }
    }
}
