using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MTNTripPlanner.Services.Identity.Application;
using MTNTripPlanner.Services.Identity.Application.Commands;
using MTNTripPlanner.Services.Identity.Application.Services;
using MTNTripPlanner.Services.Identity.Infrastructure;

namespace MTNTripPlanner.Services.Identity.API
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build())
                .Configure(app => app
                    .UseInfrastructure()
                    .UseEndpoints(endpoints => endpoints
                        // .Get("", ctx => ctx.Response.WriteAsync(ctx.RequestServices.GetService<AppOptions>().Name))
                        // .Get<GetUser>("users/{userId}", (query, ctx) => GetUserAsync(query.UserId, ctx))
                        // .Get("me", async ctx =>
                        // {
                        //     var userId = await ctx.AuthenticateUsingJwtAsync();
                        //     if (userId == Guid.Empty)
                        //     {
                        //         ctx.Response.StatusCode = 401;
                        //         return;
                        //     }
                        //
                        //     await GetUserAsync(userId, ctx);
                        // })
                        .Post<SignIn>("sign-in", async (cmd, ctx) =>
                        {
                            var token = await ctx.RequestServices.GetService<IIdentityService>().SignInAsync(cmd);
                            await ctx.Response.WriteJsonAsync(token);
                        })
                        .Post<SignUp>("sign-up", async (cmd, ctx) =>
                        {
                            await ctx.RequestServices.GetService<IIdentityService>().SignUpAsync(cmd);
                            await ctx.Response.Created("identity/me");
                        })
                        // .Post<RevokeAccessToken>("access-tokens/revoke", async (cmd, ctx) =>
                        // {
                        //     await ctx.RequestServices.GetService<IAccessTokenService>().DeactivateAsync(cmd.AccessToken);
                        //     ctx.Response.StatusCode = 204;
                        // })
                        // .Post<UseRefreshToken>("refresh-tokens/use", async (cmd, ctx) =>
                        // {
                        //     var token = await ctx.RequestServices.GetService<IRefreshTokenService>().UseAsync(cmd.RefreshToken);
                        //     await ctx.Response.WriteJsonAsync(token);
                        // })
                        // .Post<RevokeRefreshToken>("refresh-tokens/revoke", async (cmd, ctx) =>
                        // {
                        //     await ctx.RequestServices.GetService<IRefreshTokenService>().RevokeAsync(cmd.RefreshToken);
                        //     ctx.Response.StatusCode = 204;
                        // })
                    ))
                // .UseLogging()
                // .UseVault()
                .Build()
                .RunAsync();

        // private static async Task GetUserAsync(Guid id, HttpContext context)
        // {
        //     var user = await context.RequestServices.GetService<IIdentityService>().GetAsync(id);
        //     if (user is null)
        //     {
        //         context.Response.StatusCode = 404;
        //         return;
        //     }
        //
        //     await context.Response.WriteJsonAsync(user);
        // }
    }
}