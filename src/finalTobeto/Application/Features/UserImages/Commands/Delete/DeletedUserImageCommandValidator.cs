using FluentValidation;

namespace Application.Features.UserImages.Commands.Delete;

public class DeleteUserImageCommandValidator : AbstractValidator<DeleteUserImageCommand>
{
    public DeleteUserImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}