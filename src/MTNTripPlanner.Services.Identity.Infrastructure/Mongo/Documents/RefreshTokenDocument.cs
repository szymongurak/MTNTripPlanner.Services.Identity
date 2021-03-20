using System;
using Convey.Types;

namespace MTNTripPlanner.Services.Identity.Infrastructure.Mongo.Documents
{
    public class RefreshTokenDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}