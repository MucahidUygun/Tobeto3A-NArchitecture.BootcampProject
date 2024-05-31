using Application.Features.UserImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserImages.Constants.UserImagesOperationClaims;

namespace Application.Features.UserImages.Queries.GetList;

public class GetListUserImageQuery : IRequest<GetListResponse<GetListUserImageListItemDto>>, ISecuredRequest, ICachableRequest
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
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserImageListItemDto> response = _mapper.Map<GetListResponse<GetListUserImageListItemDto>>(userImages);
            return response;
        }
    }
}