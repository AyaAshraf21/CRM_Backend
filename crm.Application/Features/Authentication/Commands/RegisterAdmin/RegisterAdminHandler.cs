using crm.Application.Exceptions;
using crm.Application.Interfaces;
using crm.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Authentication.Commands.RegisterAdmin
{
    public class RegisterAdminHandler : IRequestHandler<RegisterAdminCommand>
    {
        private readonly IAuthenticationRepository authenticationRepository;

        public RegisterAdminHandler(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        public async Task Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.userDTO.Username,
            };
            var foundedUser = await authenticationRepository.GetUserByNameAsync(user.UserName);
            if(foundedUser != null)
            {
                throw new AlreadyExistsException("username");
            }
            IdentityResult identityResult = await authenticationRepository.RegisterAdminAsync(user, request.userDTO.Password);
            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.First().Description);
            }
        }
    }
}
