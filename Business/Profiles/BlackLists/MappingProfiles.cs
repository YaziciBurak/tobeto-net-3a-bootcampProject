using Business.Requests.BlackList;
using Business.Requests.Bootcamps;
using Business.Responses.Applicants;
using Business.Responses.BlackList;
using Business.Responses.Bootcamps;
using Entities.Concretes;
using AutoMapper;

namespace Business.Profiles.BlackLists;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BlackList, CreateBlackListRequest>().ReverseMap();
        CreateMap<BlackList, DeleteBlackListRequest>().ReverseMap();
        CreateMap<BlackList, UpdateBlackListRequest>().ReverseMap();

        CreateMap<BlackList, GetAllBlackListResponse>().ReverseMap();
        CreateMap<BlackList, CreateBlackListResponse>().ReverseMap();
        CreateMap<BlackList, DeleteBlackListResponse>().ReverseMap();
        CreateMap<BlackList, GetByIdBlackListResponse>().ReverseMap();
        CreateMap<BlackList, UpdateBlackListResponse>().ReverseMap();
    }
}
