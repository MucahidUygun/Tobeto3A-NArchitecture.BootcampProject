using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Auth.Commands.Register;

public class InstructorForRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string CompanyName { get; set; }


    public InstructorForRegisterDto()
    {
        Email = string.Empty;
        Password = string.Empty;
    }

    public InstructorForRegisterDto(string email, string password, string userName, string firstName,
        string lastName, DateTime dateOfBirth, string nationalIdentity, string companyName)
    {
        Email = email;
        Password = password;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        CompanyName = companyName;
    }
}
