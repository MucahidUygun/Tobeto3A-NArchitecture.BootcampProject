using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Instructors.Queries.GetList;

public class GetListInstructorListItemDto : IDto
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