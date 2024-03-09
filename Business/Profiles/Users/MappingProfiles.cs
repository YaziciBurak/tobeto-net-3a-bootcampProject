using AutoMapper;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Security.Entities;

namespace Business.Profiles.Users;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, UpdateUserRequest>().ReverseMap();

        CreateMap<User, GetAllUserResponse>().ReverseMap();
        CreateMap<User, CreateUserResponse>().ReverseMap();
        CreateMap<User, DeleteUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserResponse>().ReverseMap();
    }
}
