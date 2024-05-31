using Application.Features.BootcampImages.Commands.Delete;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.BootcampImages;

public interface IBootcampImageService
{
    Task<List<BootcampImage>> GetList();
    Task<BootcampImage> Get(int id);
    Task<BootcampImage> Add(IFormFile file, BootcampImageRequest request);
    Task<BootcampImage> Update(IFormFile file, BootcampImageUpdateRequest request);
    Task<DeletedBootcampImageResponse> Delete(int id);
    Task<List<BootcampImage>> GetImagesByBootcampId(int id);
}