using crm.Application.Exceptions;
using crm.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Authentication.Commands.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IAuthenticationRepository authenticationRepository;
        public ChangePasswordHandler(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await authenticationRepository.GetUserByNameAsync(request.username);
            if(user == null)
            {
                throw new NotFoundException("user", request.username);
            }
            bool isCorrectPassword = await authenticationRepository.CheckPasswordAsync(user, request.currentPassword);
            if (!isCorrectPassword)
            {
                throw new BadRequestException("Incorrect password , please try again");
            }
            return await authenticationRepository.ChangePassword(user, request.currentPassword, request.newPassword);
        }
    }
}
