using Application.Features.UserImages.Constants;
using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.UserImages.Constants.UserImagesOperationClaims;


namespace Application.Features.UserImages.Commands.Create;
public class CreateUserImageCommand : IRequest<CreatedUserImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }
    public string[] Roles => [Admin, Write, UserImagesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserImages"];
    public class CreateUserImageCommandHandler : IRequestHandler<CreateUserImageCommand, CreatedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public CreateUserImageCommandHandler(IMapper mapper, IUserImageRepository userImageRepository,
                                         UserImageBusinessRules userImageBusinessRules)
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<CreatedUserImageResponse> Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
        {
            UserImage userImage = _mapper.Map<UserImage>(request);

            await _userImageRepository.AddAsync(userImage);

            CreatedUserImageResponse response = _mapper.Map<CreatedUserImageResponse>(userImage);
            return response;
        }
    }
}
