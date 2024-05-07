using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;

namespace Application.Services.BootcampImages;

public interface IBootcampImageService
{
    Task<BootcampImage?> GetAsync(
        Expression<Func<BootcampImage, bool>> predicate,
        Func<IQueryable<BootcampImage>, IIncludableQueryable<BootcampImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BootcampImage>?> GetListAsync(
        Expression<Func<BootcampImage, bool>>? predicate = null,
        Func<IQueryable<BootcampImage>, IOrderedQueryable<BootcampImage>>? orderBy = null,
        Func<IQueryable<BootcampImage>, IIncludableQueryable<BootcampImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BootcampImage> AddAsync(BootcampImage bootcampImage,IFormFile formFile);
    Task<BootcampImage> UpdateAsync(BootcampImage bootcampImage,IFormFile formFile);
    Task<BootcampImage> DeleteAsync(BootcampImage bootcampImage, bool permanent = false);
}
