using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListBootcampListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string InstructorId { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public int BootcampStateId { get; set; }
    public string BootcampStateName { get; set; }
    public string ImagePath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
}