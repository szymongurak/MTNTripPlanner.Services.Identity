using System.Threading.Tasks;
using MTNTripPlanner.Services.Identity.Core.Entities;

namespace MTNTripPlanner.Services.Identity.Core.Repositories
{
    
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}