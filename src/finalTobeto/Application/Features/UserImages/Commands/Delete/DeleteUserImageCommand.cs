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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserImages.Commands.Delete;
public class DeleteUserImageCommand : IRequest<DeletedUserImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, UserImagesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserImages"];

    public class DeleteUserImageCommandHandler : IRequestHandler<DeleteUserImageCommand, DeletedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public DeleteUserImageCommandHandler(IMapper mapper, IUserImageRepository userImageRepository,
                                         UserImageBusinessRules userImageBusinessRules)
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<DeletedUserImageResponse> Handle(DeleteUserImageCommand request, CancellationToken cancellationToken)
        {
            UserImage? userImage = await _userImageRepository.GetAsync(predicate: ii => ii.Id == request.Id, cancellationToken: cancellationToken);
            await _userImageBusinessRules.UserImageShouldExistWhenSelected(userImage);

            await _userImageRepository.DeleteAsync(userImage!);

            DeletedUserImageResponse response = _mapper.Map<DeletedUserImageResponse>(userImage);
            return response;
        }
    }
}
