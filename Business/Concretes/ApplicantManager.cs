using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concrates;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _repository;

    public ApplicantManager(IApplicantRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
    {
        Applicant applicant = new Applicant();
        applicant.UserName = request.UserName;
        applicant.Password = request.Password;
        applicant.Email = request.Email;
        applicant.DateOfBirth = request.DateOfBirth;
        applicant.NationalIdentity = request.NationalIdentity;
        applicant.FirstName = request.FirstName;
        applicant.LastName = request.LastName;
        applicant.About = request.About;
        await _repository.AddAsync(applicant);

        CreateApplicantResponse response = new CreateApplicantResponse();
        response.UserId = applicant.Id;
        response.About = applicant.About;
        return response;
    }

    public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
    {
        Applicant applicant = new Applicant();
        applicant.Id = request.UserId;
        await _repository.DeleteAsync(applicant);

        DeleteApplicantResponse response = new DeleteApplicantResponse();
        response.UserId = applicant.Id;
        return response;
    }

    public async Task<List<GetAllApplicantResponse>> GetAll()
    {
        List<GetAllApplicantResponse> applicants = new List<GetAllApplicantResponse>();
        foreach (var applicant in await _repository.GetAllAsync())
        {
            GetAllApplicantResponse applicantResponse = new GetAllApplicantResponse();
            applicantResponse.UserId = applicant.Id;
            applicantResponse.About = applicant.About;
            applicants.Add(applicantResponse);
        }
        return applicants;
    }

    public async Task<GetByIdApplicantResponse> GetById(int id)
    {
       GetByIdApplicantResponse response = new GetByIdApplicantResponse();
        Applicant applicant = await _repository.GetAsync(a => a.Id == id);
        response.UserId = applicant.Id;
        response.About = applicant.About;
        return response;
    }

    public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        Applicant applicant = await _repository.GetAsync(a => a.Id == request.UserId);
        applicant.Id = request.UserId;
        applicant.UserName = request.UserName;
        applicant.Password = request.Password;
        applicant.Email = request.Email;
        applicant.DateOfBirth = request.DateOfBirth;
        applicant.NationalIdentity = request.NationalIdentity;
        applicant.FirstName = request.FirstName;
        applicant.LastName = request.LastName;
        applicant.About = request.About;
        await _repository.UpdateAsync(applicant);

        UpdateApplicantResponse response = new UpdateApplicantResponse();
        response.UserId = applicant.Id;
        response.UserName = applicant.UserName;
        response.FirstName = applicant.FirstName;
        response.LastName = applicant.LastName;
        response.DateOfBirth = applicant.DateOfBirth;
        response.NationalIdentity = applicant.NationalIdentity;
        response.Email = applicant.Email;
        response.Password = applicant.Password;
        response.About = applicant.About;
        return response;

    }
}
