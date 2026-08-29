using crm.Application.Features.Tags.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Tags.Queries.GetAllTags
{
    public record GetAllTagsQuery : IRequest<List<TagResponseDTO>>;
}
