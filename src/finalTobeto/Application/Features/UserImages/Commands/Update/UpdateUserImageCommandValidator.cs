using FluentValidation;

namespace Application.Features.UserImages.Commands.Update;

public class UpdateUserImageCommandValidator : AbstractValidator<UpdateUserImageCommand>
{
    public UpdateUserImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}