using Convey.CQRS.Commands;

namespace MTNTripPlanner.Services.Identity.Application.Commands
{
    public class RevokeAccessToken : ICommand
    {
        public string AccessToken { get; }

        public RevokeAccessToken(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}