using FluentValidation;

namespace Application.Features.UserImages.Commands.Create;

public class CreateUserImageCommandValidator : AbstractValidator<CreateUserImageCommand>
{
    public CreateUserImageCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}