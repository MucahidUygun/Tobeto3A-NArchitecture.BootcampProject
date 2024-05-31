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

namespace Application.Features.UserImages.Commands.Update;
public class UpdateUserImageCommand : IRequest<UpdatedUserImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }

    public string[] Roles => [Admin, Write, UserImagesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserImages"];

    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, UpdatedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public UpdateUserImageCommandHandler(IMapper mapper, IUserImageRepository userImageRepository,
                                         UserImageBusinessRules userImageBusinessRules)
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<UpdatedUserImageResponse> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            UserImage? userImage = await _userImageRepository.GetAsync(predicate: ii => ii.Id == request.Id, cancellationToken: cancellationToken);
            await _userImageBusinessRules.UserImageShouldExistWhenSelected(userImage);
            userImage = _mapper.Map(request, userImage);

            await _userImageRepository.UpdateAsync(userImage!);

            UpdatedUserImageResponse response = _mapper.Map<UpdatedUserImageResponse>(userImage);
            return response;
        }
    }
}
