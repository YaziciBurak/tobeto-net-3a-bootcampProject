using AutoMapper;
using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applicants;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Entities.Concretes;
using Entities.Entity;

namespace Business.Profiles.ApplicationStates;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationState, CreateApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, DeleteApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, UpdateApplicationStateRequest>().ReverseMap();

        CreateMap<ApplicationState, GetAllApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, CreateApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, DeleteApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, GetByIdApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, UpdateApplicationStateResponse>().ReverseMap();

    }
}
