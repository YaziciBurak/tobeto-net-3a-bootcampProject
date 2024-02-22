using AutoMapper;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Entities.Concretes;

namespace Business.Profiles.BootcampStates;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampState, CreateBootcampRequest>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateRequest>().ReverseMap(); 
        CreateMap<BootcampState, UpdateBootcampStateRequest>().ReverseMap();

        CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, CreateBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateResponse>().ReverseMap();
    }
}
