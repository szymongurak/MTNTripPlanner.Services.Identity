using System;
using System.Collections.Generic;
using System.Linq;
using MTNTripPlanner.Services.Identity.Core.Exceptions;

namespace MTNTripPlanner.Services.Identity.Core.Entities
{
    public class User : AggregateRoot
    {
        public string Email { get; private set; }
        public string Role { get; }
        public string Password { get; }
        public DateTime CreatedAt { get; }
        public IEnumerable<string> Permissions { get; }

        public User(Guid id, string email, string password, string role, DateTime createdAt,
            IEnumerable<string> permissions = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidEmailException(email);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidPasswordException();
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                throw new InvalidRoleException(role);
            }

            Id = id;
            Email = email.ToLowerInvariant();
            Password = password;
            Role = role.ToLowerInvariant();
            CreatedAt = createdAt;
            Permissions = permissions ?? Enumerable.Empty<string>();
        }
    }
}