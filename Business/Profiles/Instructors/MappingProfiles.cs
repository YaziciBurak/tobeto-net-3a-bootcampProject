using AutoMapper;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Entities.Concrates;
using Entities.Concretes;

namespace Business.Profiles.Instructors;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();

        CreateMap<Instructor, GetAllnstructorResponse>().ReverseMap();
        CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();
    }
}
