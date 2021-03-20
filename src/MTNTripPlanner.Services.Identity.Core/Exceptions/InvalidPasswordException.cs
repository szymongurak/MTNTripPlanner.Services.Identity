using MTNTripPlanner.Services.Identity.Core.Exceptions;

namespace MTNTripPlanner.Services.Identity.Core.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public override string Code { get; } = "invalid_password";

        public InvalidPasswordException() : base($"invalid_password")
        {
        }
    }
}