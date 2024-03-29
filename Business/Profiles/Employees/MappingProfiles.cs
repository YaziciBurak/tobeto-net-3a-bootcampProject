﻿using AutoMapper;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Requests.Employees;
using Business.Responses.BootcampStates;
using Business.Responses.Employees;
using Entities.Concrates;
using Entities.Concretes;

namespace Business.Profiles.Employees;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
        CreateMap<Employee, DeleteEmployeeRequest>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();

        CreateMap<Employee, GetAllEmployeeResponse>().ReverseMap();
        CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();
        CreateMap<Employee, DeleteEmployeeResponse>().ReverseMap();
        CreateMap<Employee, GetByIdEmployeeResponse>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();
    }
}
