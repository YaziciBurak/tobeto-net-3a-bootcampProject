using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Employees;
using Business.Responses.Instructors;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrates;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    internal class InstructorManager : IInstructorService
    {

        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;



        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _repository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _repository.AddAsync(instructor);

            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
            return new SuccessDataResult<CreateInstructorResponse>(response, "Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = await _repository.GetAsync(x => x.Id == request.Id);
            await _repository.DeleteAsync(instructor);
            return new SuccessResult("Silme Başarılı");
        }

        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAll()
        {
            List<Instructor> instructors = await _repository.GetAllAsync();
            List<GetAllInstructorResponse> responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
            return new SuccessDataResult<List<GetAllInstructorResponse>>(responses, "Listeleme Başarılı");
        }

        public async Task<IDataResult<GetByIdInstructorResponse>> GetById(int id)
        {
            Instructor instructor = await _repository.GetAsync(x => x.Id == id);
            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return new SuccessDataResult<GetByIdInstructorResponse>(response, "GetById İşlemi Başarılı");
        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _repository.UpdateAsync(instructor);
            UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(response, "Update İşlemi Başarılı");
        }
    }
}
