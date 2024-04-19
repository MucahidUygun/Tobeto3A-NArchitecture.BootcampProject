using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Auth.Commands.Register;

public class ApplicantForRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string About { get; set; }


    public ApplicantForRegisterDto()
    {
        Email = string.Empty;
        Password = string.Empty;
    }

    public ApplicantForRegisterDto(string email, string password, string userName, string firstName,
        string lastName, DateTime dateOfBirth, string nationalIdentity, string about)
    {
        Email = email;
        Password = password;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        About = about;
    }
}
