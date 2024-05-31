using NArchitecture.Core.Application.Responses;

namespace Application.Features.Applicants.Queries.GetById;

public class GetByIdApplicantResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateofBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
    public string ImagePath { get; set; }
}