using System.Threading.Tasks;
using Convey.CQRS.Events;
using MTNTripPlanner.Services.Identity.Application.Services;

namespace MTNTripPlanner.Services.Identity.Infrastructure.Services
{
    public class MessageBroker : IMessageBroker
    {
        public Task PublishAsync(params IEvent[] events)
        {
            throw new System.NotImplementedException();
        }
    }
}