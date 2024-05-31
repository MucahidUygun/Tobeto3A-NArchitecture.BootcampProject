using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.ForgotPassword;
public class ForgotPasswordCommand:IRequest
{
    public ForgotPasswordDto ForgotPasswordDto { get; set; }

    public ForgotPasswordCommand()
    {
        
    }

    public ForgotPasswordCommand(ForgotPasswordDto forgotPasswordDto)
    {
        ForgotPasswordDto = forgotPasswordDto;
    }

    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;

        public ForgotPasswordCommandHandler(IUserService userService, IMailService mailService, AuthBusinessRules authBusinessRules, IEmailAuthenticatorRepository emailAuthenticatorRepository, IAuthService authService)
        {
            _userService = userService;
            _mailService = mailService;
            _authBusinessRules = authBusinessRules;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _authService = authService;
        }

        public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(predicate: u => u.Email == request.ForgotPasswordDto.Email, cancellationToken: cancellationToken);

            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

            var emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);
            await _authBusinessRules.PasswordResetRequestBeExists(emailAuthenticator);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            createdAccessToken.ExpirationDate = DateTime.Now.AddMinutes(10);

            emailAuthenticator.ResetPasswordToken = true;
            emailAuthenticator.ResetPasswordTokenExpiry = createdAccessToken.ExpirationDate;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            var toEmailList = new List<MailboxAddress> { new(name: user.Email, user.Email) };

            string ResetPasswordLink = $"http://localhost:4200/reset-password?token={createdAccessToken.Token}";

            string htmlFilePath = Path.Combine("wwwroot", "emails", "EmailVerify.html");

            string htmlContent = File.ReadAllText(htmlFilePath);

            htmlContent = htmlContent.Replace("{{VerifyLink}}", ResetPasswordLink);

            _mailService.SendMail(
                new Mail
                {
                    ToList = toEmailList,
                    Subject = "Şifre Yenileme - NArchitecture",
                    TextBody =
                        $"Link Üzerinde Şifrenizi değişirebilirsiniz :  {ResetPasswordLink}",
                    HtmlBody = htmlContent
                }
            );

        }
    }
}
