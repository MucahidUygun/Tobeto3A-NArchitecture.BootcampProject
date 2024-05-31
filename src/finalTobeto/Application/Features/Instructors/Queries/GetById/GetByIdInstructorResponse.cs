using NArchitecture.Core.Application.Responses;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public string userName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string CompanyName { get; set; }
}