using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using DataAccess.Abstracts;
using Entities.Concrates;

namespace Business.Concretes
{
    internal class InstructorManager : IInstructorService
    {

        private readonly IInstructorRepository _instructorRepository;

        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new Instructor();
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Add(instructor);
            
            CreateInstructorResponse response = new CreateInstructorResponse();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;
        }

        public async Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = new Instructor();
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Delete(instructor);

            DeleteInstructorResponse response = new DeleteInstructorResponse();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;
        }

        public async Task<List<GetAllnstructorResponse>> GetAll()
        {
            List<GetAllnstructorResponse> getAllnstructorResponses = new List<GetAllnstructorResponse>();
            foreach (var instructor in await _instructorRepository.GetAll())
            {
                GetAllnstructorResponse response = new GetAllnstructorResponse();
                response.UserId = instructor.Id;
                response.CompanyName = instructor.CompanyName;
                getAllnstructorResponses.Add(response);
            }
            return getAllnstructorResponses;
        }

        public async Task<GetByIdInstructorResponse> GetById(int id)
        {
            GetByIdInstructorResponse response = new GetByIdInstructorResponse();
            Instructor instructor = await _instructorRepository.Get(i => i.Id == id);
            response.CompanyName = instructor.CompanyName;
            return response;

        }

        public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.Get(i => i.Id == request.UserId);
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Update(instructor);

            UpdateInstructorResponse response = new UpdateInstructorResponse();
            response.UserId = request.UserId;
            response.CompanyName = request.CompanyName;
            return response;
        }
    }
}
