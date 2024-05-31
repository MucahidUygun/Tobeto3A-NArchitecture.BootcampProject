using Application.Features.UserImages.Commands.Create;
using Application.Features.UserImages.Commands.Delete;
using Application.Features.UserImages.Commands.Update;
using Application.Features.UserImages.Queries.GetById;
using Application.Features.UserImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Services.UserImages;

namespace Application.Features.UserImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserImage, CreateUserImageCommand>().ReverseMap();
        CreateMap<UserImage, CreatedUserImageResponse>().ReverseMap();
        CreateMap<UserImage, UpdateUserImageCommand>().ReverseMap();
        CreateMap<UserImage, UpdatedUserImageResponse>().ReverseMap();
        CreateMap<UserImage, DeleteUserImageCommand>().ReverseMap();
        CreateMap<UserImage, DeletedUserImageResponse>().ReverseMap();
        CreateMap<UserImage, GetByIdUserImageResponse>().ReverseMap();
        CreateMap<UserImage, GetListUserImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserImage>, GetListResponse<GetListUserImageListItemDto>>().ReverseMap();
        CreateMap<UserImageUpdateRequest, UserImage>().ReverseMap();
    }
}