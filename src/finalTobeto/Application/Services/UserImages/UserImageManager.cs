using Application.Features.UserImages.Commands.Delete;
using Application.Features.UserImages.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserImages;
public class UserImageManager : IUserImageService, ICacheRemoverRequest
{
    private readonly IUserImageRepository _userImageRepository;
    private readonly UserImageBusinessRules _userImageBusinessRules;
    private readonly ImageServiceBase _imageService;
    private readonly IMapper _mapper;
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserImages"];
    public UserImageManager(IUserImageRepository userImageRepository, UserImageBusinessRules userImageBusinessRules,
        ImageServiceBase imageServiceBase, IMapper mapper)
    {
        _userImageRepository = userImageRepository;
        _userImageBusinessRules = userImageBusinessRules;
        _imageService = imageServiceBase;
        _mapper = mapper;
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

    public async Task<UserImage> AddAsync(IFormFile file, UserImageRequest request)
    {
        UserImage userImage = new UserImage() { UserId = request.UserId };
        userImage.ImagePath = await _imageService.UploadAsync(file);
        return await _userImageRepository.AddAsync(userImage);

    }

    public async Task<UserImage> UpdateAsync(IFormFile file, UserImageUpdateRequest request)
    {
        UserImage userImage = await _userImageRepository.GetAsync(x => x.Id == request.Id);
        userImage = _mapper.Map(request, userImage);
        userImage.ImagePath = await _imageService.UpdateAsync(file, userImage.ImagePath);
        await _userImageRepository.UpdateAsync(userImage);
        return userImage;
    }

    public async Task<DeletedUserImageResponse> DeleteAsync(int id)
    {
        UserImage userImage = await _userImageRepository.GetAsync(x => x.Id == id);
        await _imageService.DeleteAsync(userImage.ImagePath);
        await _userImageRepository.DeleteAsync(userImage, true);

        DeletedUserImageResponse response = _mapper.Map<DeletedUserImageResponse>(userImage);
        return response;

    }
}
