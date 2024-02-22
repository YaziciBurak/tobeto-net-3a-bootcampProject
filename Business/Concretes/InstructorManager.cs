using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrates;
using Entities.Concretes;

namespace Business.Concretes
{
    internal class InstructorManager : IInstructorService
    {

        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

       

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new();
            instructor.UserName = request.UserName;
            instructor.Password = request.Password;
            instructor.Email = request.Email;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.AddAsync(instructor);

            CreateInstructorResponse response = new CreateInstructorResponse();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;
        }

        public async Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = new Instructor();
            instructor.Id = request.UserId;
            await _instructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse response = new DeleteInstructorResponse();
            response.UserId = instructor.Id;
            return response;
        }

        public async Task<IDataResult<List<GetAllnstructorResponse>>> GetAll()
        {
            List<GetAllnstructorResponse> getAllnstructorResponses = new List<GetAllnstructorResponse>();
            foreach (var instructor in await _instructorRepository.GetAllAsync())
            {
                GetAllnstructorResponse response = new GetAllnstructorResponse();
                response.UserId = instructor.Id;
                response.CompanyName = instructor.CompanyName;
                getAllnstructorResponses.Add(response);
            }
            return getAllnstructorResponses;
        }

        public async Task<IDataResult<GetByIdInstructorResponse>> GetById(int id)
        {
            GetByIdInstructorResponse response = new GetByIdInstructorResponse();
            Instructor instructor = await _instructorRepository.GetAsync(i => i.Id == id);
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;

        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.UserId);
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            instructor.UserName = request.UserName;
            instructor.LastName = request.LastName;
            instructor.FirstName = request.FirstName;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Email = request.Email;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.Password = request.Password;
            await _instructorRepository.UpdateAsync(instructor);

            UpdateInstructorResponse response = new UpdateInstructorResponse();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            response.UserName = instructor.UserName;
            response.Password = instructor.Password;
            response.NationalIdentity = instructor.NationalIdentity;
            response.LastName = instructor.LastName;
            response.FirstName = instructor.FirstName;
            response.DateOfBirth = instructor.DateOfBirth;
            response.Email = instructor.Email;
            return response;
        }
    }
}
