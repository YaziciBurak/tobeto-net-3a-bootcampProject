using AutoMapper;
using Business.Requests.Applicants;
using Business.Requests.Bootcamps;
using Business.Responses.Applicants;
using Business.Responses.Bootcamps;
using Entities.Concretes;

namespace Business.Profiles.Bootcamps;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();

        CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, CreateBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetByIdApplicantResponse>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampResponse>().ReverseMap();
    }
}
