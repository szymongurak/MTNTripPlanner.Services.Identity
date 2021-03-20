using System;

namespace MTNTripPlanner.Services.Identity.Core.Exceptions
{
    public class DomainException : Exception
    {
        public virtual string Code { get; }

        public DomainException(string message) : base(message)
        {
        }
    }
}