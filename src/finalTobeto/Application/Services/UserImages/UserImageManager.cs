using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserImages;

public class UserImageManager : IUserImageService
{
    private readonly IUserImageRepository _userImageRepository;
    private readonly UserImageBusinessRules _userImageBusinessRules;

    public UserImageManager(IUserImageRepository userImageRepository, UserImageBusinessRules userImageBusinessRules)
    {
        _userImageRepository = userImageRepository;
        _userImageBusinessRules = userImageBusinessRules;
    }

    public async Task<UserImage?> GetAsync(
        Expression<Func<UserImage, bool>> predicate,
        Func<IQueryable<UserImage>, IIncludableQueryable<UserImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserImage? userImage = await _userImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userImage;
    }

    public async Task<IPaginate<UserImage>?> GetListAsync(
        Expression<Func<UserImage, bool>>? predicate = null,
        Func<IQueryable<UserImage>, IOrderedQueryable<UserImage>>? orderBy = null,
        Func<IQueryable<UserImage>, IIncludableQueryable<UserImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserImage> userImageList = await _userImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userImageList;
    }

    public async Task<UserImage> AddAsync(UserImage userImage)
    {
        UserImage addedUserImage = await _userImageRepository.AddAsync(userImage);

        return addedUserImage;
    }

    public async Task<UserImage> UpdateAsync(UserImage userImage)
    {
        UserImage updatedUserImage = await _userImageRepository.UpdateAsync(userImage);

        return updatedUserImage;
    }

    public async Task<UserImage> DeleteAsync(UserImage userImage, bool permanent = false)
    {
        UserImage deletedUserImage = await _userImageRepository.DeleteAsync(userImage);

        return deletedUserImage;
    }
}
