using Application.Features.UserImages.Constants;
using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserImages.Constants.UserImagesOperationClaims;

namespace Application.Features.UserImages.Queries.GetById;

public class GetByIdUserImageQuery : IRequest<GetByIdUserImageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUserImageQueryHandler : IRequestHandler<GetByIdUserImageQuery, GetByIdUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public GetByIdUserImageQueryHandler(IMapper mapper, IUserImageRepository userImageRepository, UserImageBusinessRules userImageBusinessRules)
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<GetByIdUserImageResponse> Handle(GetByIdUserImageQuery request, CancellationToken cancellationToken)
        {
            UserImage? userImage = await _userImageRepository.GetAsync(predicate: ui => ui.Id == request.Id, cancellationToken: cancellationToken);
            await _userImageBusinessRules.UserImageShouldExistWhenSelected(userImage);

            GetByIdUserImageResponse response = _mapper.Map<GetByIdUserImageResponse>(userImage);
            return response;
        }
    }
}