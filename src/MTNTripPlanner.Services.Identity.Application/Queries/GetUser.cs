using System;
using Convey.CQRS.Queries;
using MTNTripPlanner.Services.Identity.Application.DTO;

namespace MTNTripPlanner.Services.Identity.Application.Queries
{
    public class GetUser : IQuery<UserDto>
    {
        public Guid UserId { get; set; }
    }
}