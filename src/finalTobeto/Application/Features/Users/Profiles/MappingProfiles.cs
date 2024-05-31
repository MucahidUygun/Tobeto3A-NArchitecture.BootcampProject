using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserFromAuthCommand>().ReverseMap();
        CreateMap<User, UpdatedUserFromAuthResponse>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().
            ForMember(destinationMember: x => x.UserImagePath, memberOptions: opt => opt.MapFrom(x => x.UserImages.FirstOrDefault().ImagePath))
        .ForMember(destinationMember: x => x.UserImageId, memberOptions: opt => opt.MapFrom(x => x.UserImages.FirstOrDefault().Id));
        CreateMap<User, GetListUserListItemDto>().
            ForMember(destinationMember: x => x.UserImagePath, memberOptions: opt => opt.MapFrom(x => x.UserImages.FirstOrDefault().ImagePath))
        .ForMember(destinationMember: x => x.UserImageId, memberOptions: opt => opt.MapFrom(x => x.UserImages.FirstOrDefault().Id));
        CreateMap<IPaginate<User>, GetListResponse<GetListUserListItemDto>>().ReverseMap();
    }
}
