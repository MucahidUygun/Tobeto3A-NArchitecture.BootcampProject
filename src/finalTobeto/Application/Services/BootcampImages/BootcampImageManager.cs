using Application.Features.BootcampImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;

namespace Application.Services.BootcampImages;

public class BootcampImageManager : IBootcampImageService
{
    private readonly IBootcampImageRepository _bootcampImageRepository;
    private readonly BootcampImageBusinessRules _bootcampImageBusinessRules;
    private readonly ImageServiceBase _imageServiceBase;

    public BootcampImageManager(IBootcampImageRepository bootcampImageRepository, BootcampImageBusinessRules bootcampImageBusinessRules,ImageServiceBase imageServiceBase)
    {
        _imageServiceBase = imageServiceBase;
        _bootcampImageRepository = bootcampImageRepository;
        _bootcampImageBusinessRules = bootcampImageBusinessRules;
    }

    public async Task<BootcampImage?> GetAsync(
        Expression<Func<BootcampImage, bool>> predicate,
        Func<IQueryable<BootcampImage>, IIncludableQueryable<BootcampImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BootcampImage? bootcampImage = await _bootcampImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bootcampImage;
    }

    public async Task<IPaginate<BootcampImage>?> GetListAsync(
        Expression<Func<BootcampImage, bool>>? predicate = null,
        Func<IQueryable<BootcampImage>, IOrderedQueryable<BootcampImage>>? orderBy = null,
        Func<IQueryable<BootcampImage>, IIncludableQueryable<BootcampImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BootcampImage> bootcampImageList = await _bootcampImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampImageList;
    }

    public async Task<BootcampImage> DeleteAsync(BootcampImage bootcampImage, bool permanent = false)
    {
        BootcampImage deletedBootcampImage = await _bootcampImageRepository.DeleteAsync(bootcampImage);

        return deletedBootcampImage;
    }

    public async Task<BootcampImage> AddAsync(BootcampImage bootcampImage, IFormFile formFile)
    {
        BootcampImage Image = new()
        {
            BootcampId = bootcampImage.BootcampId,
            ImagePath = bootcampImage.ImagePath
        };
        Image.ImagePath = await _imageServiceBase.UploadAsync(formFile);



        return await _bootcampImageRepository.AddAsync(Image);
    }

    public async Task<BootcampImage> UpdateAsync(BootcampImage bootcampImage, IFormFile formFile)
    {
        bootcampImage.ImagePath = await _imageServiceBase.UpdateAsync(formFile, bootcampImage.ImagePath);
        BootcampImage updatedBootcampImage = await _bootcampImageRepository.UpdateAsync(bootcampImage);

        return updatedBootcampImage;
    }
}
