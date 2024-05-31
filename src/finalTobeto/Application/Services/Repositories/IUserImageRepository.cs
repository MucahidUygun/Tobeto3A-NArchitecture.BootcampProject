using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserImageRepository : IAsyncRepository<UserImage, int>, IRepository<UserImage, int>
{
}