using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{
    public AccessToken? AccessToken { get; set; }
    public Domain.Entities.RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public LoggedHttpResponse ToHttpResponse()
    {
        try
        {
            return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }

    public class LoggedHttpResponse
    {
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    }
}
