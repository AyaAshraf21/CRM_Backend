using crm.Application.Exceptions;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Commands.DeleteFollowup
{
    public class DeleteFollowupHandler : IRequestHandler<DeleteFollowupCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFollowupRepository followupRepository;

        public DeleteFollowupHandler(IUnitOfWork unitOfWork, IFollowupRepository followupRepository)
        {
            this.unitOfWork = unitOfWork;
            this.followupRepository = followupRepository;
        }
        public async Task Handle(DeleteFollowupCommand request, CancellationToken cancellationToken)
        {
            var followup = await followupRepository.GetFollowupByIdAsync(request.id);
            if(followup == null)
            {
                throw new NotFoundException("Followup", request.id);
            }
            followup.IsDeleted = true;
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
