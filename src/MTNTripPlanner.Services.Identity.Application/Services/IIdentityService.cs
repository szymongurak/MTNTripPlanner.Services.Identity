using System;
using System.Threading.Tasks;
using MTNTripPlanner.Services.Identity.Application.Commands;
using MTNTripPlanner.Services.Identity.Application.DTO;
using MTNTripPlanner.Services.Identity.Core.Entities;

namespace MTNTripPlanner.Services.Identity.Application.Services
{
    public interface IIdentityService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<AuthDto> SignInAsync(SignIn command);
        Task SignUpAsync(SignUp command);
    }
}