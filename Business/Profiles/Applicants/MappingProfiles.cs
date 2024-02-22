using AutoMapper;
using Business.Requests.Applicants;
using Business.Requests.Applications;
using Business.Responses.Applicants;
using Business.Responses.Applications;
using Entities.Concretes;

namespace Business.Profiles.Applicants;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();

        CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        CreateMap<Applicant, CreateApplicantResponse>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();

    }
}
