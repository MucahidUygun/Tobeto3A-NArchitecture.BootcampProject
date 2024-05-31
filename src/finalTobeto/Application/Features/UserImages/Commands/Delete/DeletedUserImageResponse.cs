using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserImages.Commands.Delete;

public class DeletedUserImageResponse : IResponse
{
    public int Id { get; set; }
}