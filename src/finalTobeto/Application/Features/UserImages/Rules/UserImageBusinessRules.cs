using Application.Features.UserImages.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserImages.Rules;
public class UserImageBusinessRules : BaseBusinessRules
{
    private readonly IUserImageRepository _userImageRepository;
    private readonly ILocalizationService _localizationService;

    public UserImageBusinessRules(IUserImageRepository userImageRepository, ILocalizationService localizationService)
    {
        _userImageRepository = userImageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserImageShouldExistWhenSelected(UserImage? userImage)
    {
        if (userImage == null)
            await throwBusinessException(UserImagesBusinessMessages.UserImageNotExists);
    }

    public async Task UserImageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserImage? userImage = await _userImageRepository.GetAsync(
            predicate: ii => ii.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserImageShouldExistWhenSelected(userImage);
    }
}
