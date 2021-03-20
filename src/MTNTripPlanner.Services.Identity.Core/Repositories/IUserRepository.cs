using System;
using System.Threading.Tasks;
using MTNTripPlanner.Services.Identity.Core.Entities;

namespace MTNTripPlanner.Services.Identity.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}