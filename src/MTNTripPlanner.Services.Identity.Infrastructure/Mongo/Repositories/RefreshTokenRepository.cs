using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using MTNTripPlanner.Services.Identity.Core.Entities;
using MTNTripPlanner.Services.Identity.Core.Repositories;
using MTNTripPlanner.Services.Identity.Infrastructure.Mongo.Documents;

namespace MTNTripPlanner.Services.Identity.Infrastructure.Mongo.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IMongoRepository<RefreshTokenDocument, Guid> _repository;

        public RefreshTokenRepository(IMongoRepository<RefreshTokenDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<RefreshToken> GetAsync(string token)
        {
            var refreshToken = await _repository.GetAsync(x => x.Token == token);

            return refreshToken?.AsEntity();
        }

        public Task AddAsync(RefreshToken token) => _repository.AddAsync(token.AsDocument());

        public Task UpdateAsync(RefreshToken token) => _repository.UpdateAsync(token.AsDocument());
    }
}