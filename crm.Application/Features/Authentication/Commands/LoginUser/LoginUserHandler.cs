using crm.Application.Exceptions;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Authentication.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthenticationRepository authenticationRepository;
        private readonly IJwtRepository jwtRepository;

        public LoginUserHandler(IAuthenticationRepository authenticationRepository, IJwtRepository jwtRepository)
        {
            this.authenticationRepository = authenticationRepository;
            this.jwtRepository = jwtRepository;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await authenticationRepository.GetUserByNameAsync(request.userDTO.Username);
            if(user == null)
            {
                throw new NotFoundException("User", request.userDTO.Username);
            }
            bool check = await authenticationRepository.CheckPasswordAsync(user, request.userDTO.Password);
            if (!check)
            {
                throw new BadRequestException("Invalid Credentials, please try again");
            }
            return await jwtRepository.GenerateToken(user);
        }
    }
}
