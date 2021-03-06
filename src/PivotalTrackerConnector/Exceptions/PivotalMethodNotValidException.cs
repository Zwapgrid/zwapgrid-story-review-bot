﻿using System;

namespace PivotalTrackerConnector.Exceptions
{
    public class PivotalMethodNotValidException : PivotalException
    {
        public PivotalMethodNotValidException() : base() { }
        public PivotalMethodNotValidException(string message) : base(message) { }
        public PivotalMethodNotValidException(string message, Exception innerException) : base(message, innerException) { }
    }
}
