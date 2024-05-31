using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.UserImages.Constants.UserImagesOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserImages.Queries.GetList;
public class GetListUserImageQuery : IRequest<GetListResponse<GetListUserImageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserImageQueryHandler : IRequestHandler<GetListUserImageQuery, GetListResponse<GetListUserImageListItemDto>>
    {
        private readonly IUserImageRepository _userImageRepository;
        private readonly IMapper _mapper;

        public GetListUserImageQueryHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _userImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserImageListItemDto>> Handle(GetListUserImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserImage> userImages = await _userImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: x => x.Include(x => x.User)
            );

            GetListResponse<GetListUserImageListItemDto> response = _mapper.Map<GetListResponse<GetListUserImageListItemDto>>(userImages);
            return response;
        }
    }
}
