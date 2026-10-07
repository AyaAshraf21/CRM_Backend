using crm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Authentication.Commands.ChangePassword
{
    public record ChangePasswordCommand(string username, string currentPassword, string newPassword) : IRequest<bool>;
}
