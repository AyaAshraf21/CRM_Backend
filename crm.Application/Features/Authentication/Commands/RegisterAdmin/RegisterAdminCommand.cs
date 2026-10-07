using crm.Application.Features.Authentication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Authentication.Commands.RegisterAdmin
{
    public record RegisterAdminCommand(UserDTO userDTO) : IRequest;
}
