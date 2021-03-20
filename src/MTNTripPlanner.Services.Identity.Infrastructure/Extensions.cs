using System;
using Convey;
using Convey.Auth;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MTNTripPlanner.Services.Identity.Application.Services;
using MTNTripPlanner.Services.Identity.Application.Services.Identity;
using MTNTripPlanner.Services.Identity.Core.Repositories;
using MTNTripPlanner.Services.Identity.Infrastructure.Auth;
using MTNTripPlanner.Services.Identity.Infrastructure.Mongo;
using MTNTripPlanner.Services.Identity.Infrastructure.Mongo.Documents;
using MTNTripPlanner.Services.Identity.Infrastructure.Mongo.Repositories;
using MTNTripPlanner.Services.Identity.Infrastructure.Services;

namespace MTNTripPlanner.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddSingleton<IJwtProvider, JwtProvider>();
            builder.Services.AddSingleton<IPasswordService, PasswordService>();
            builder.Services.AddSingleton<IPasswordHasher<IPasswordService>, PasswordHasher<IPasswordService>>();
            builder.Services.AddTransient<IIdentityService, IdentityService>();
            builder.Services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            builder.Services.AddTransient<IUserRepository, UserMongoRepository>();
            builder.Services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddSingleton<IRng, Rng>();
            
            return builder
                .AddJwt()
                .AddMongo()
                .AddMongoRepository<UserDocument, Guid>("users")
                .AddMongoRepository<RefreshTokenDocument, Guid>("refreshTokens");
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseMongo();
            
            return app;
        }
    }
}