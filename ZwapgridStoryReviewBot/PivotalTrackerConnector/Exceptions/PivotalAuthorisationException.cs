using System;

namespace PivotalTrackerConnector.Exceptions
{
    public class PivotalAuthorisationException : Exception
    {
        public PivotalAuthorisationException() : base() { }
        public PivotalAuthorisationException(string message) : base(message) { }
        public PivotalAuthorisationException(string message, Exception innerException) :base(message, innerException) { }
    }
}
