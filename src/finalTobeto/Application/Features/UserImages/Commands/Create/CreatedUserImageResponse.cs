using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserImages.Commands.Create;

public class CreatedUserImageResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }
}