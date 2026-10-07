using crm.Application.Exceptions;
using crm.Application.Interfaces;
using crm.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Authentication.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IAuthenticationRepository authenticationRepository;

        public RegisterUserHandler(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.userDTO.Username,
            };
            var foundedUser = await authenticationRepository.GetUserByNameAsync(user.UserName);
            if (foundedUser != null)
            {
                throw new AlreadyExistsException("username");
            }
            IdentityResult identityResult = await authenticationRepository.RegisterEmployeeAsync(user, request.userDTO.Password);
            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.First().Description);
            }
        }
    }
}
