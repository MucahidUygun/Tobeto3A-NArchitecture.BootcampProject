using Application.Features.UserImages.Commands.Delete;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserImages;
public interface IUserImageService
{
    Task<UserImage?> GetAsync(
        Expression<Func<UserImage, bool>> predicate,
        Func<IQueryable<UserImage>, IIncludableQueryable<UserImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserImage>?> GetListAsync(
        Expression<Func<UserImage, bool>>? predicate = null,
        Func<IQueryable<UserImage>, IOrderedQueryable<UserImage>>? orderBy = null,
        Func<IQueryable<UserImage>, IIncludableQueryable<UserImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserImage> AddAsync(IFormFile file, UserImageRequest request);
    Task<UserImage> UpdateAsync(IFormFile file, UserImageUpdateRequest request);
    Task<DeletedUserImageResponse> DeleteAsync(int id);
}
