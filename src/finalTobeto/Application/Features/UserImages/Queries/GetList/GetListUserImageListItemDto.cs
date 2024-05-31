using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserImages.Queries.GetList;
public class GetListUserImageListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string ImagePath { get; set; }
}
