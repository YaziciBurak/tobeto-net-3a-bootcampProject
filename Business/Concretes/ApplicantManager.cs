using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using Entities.Concrates;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _repository;

    public ApplicantManager(IApplicantRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateApplicantResponse> AddASync(CreateApplicantRequest request)
    {
        Applicant applicant = new Applicant();
        applicant.Id = request.UserId;
        applicant.About = request.About;
        await _repository.Add(applicant);

        CreateApplicantResponse response = new CreateApplicantResponse();
        response.UserId = applicant.Id;
        response.About = applicant.About;
        return response;

    }

    public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
    {
        Applicant applicant = new Applicant();
        applicant.Id = request.UserId;
        applicant.About = request.About;
        await _repository.Delete(applicant);

        DeleteApplicantResponse response = new DeleteApplicantResponse();
        response.UserId = applicant.Id;
        response.About = applicant.About;
        return response;
    }

    public async Task<List<GetAllApplicantResponse>> GetAll()
    {
        List<GetAllApplicantResponse> applicants = new List<GetAllApplicantResponse>();
        foreach (var applicant in await _repository.GetAll())
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
        Applicant applicant = await _repository.Get(a => a.Id == id);
        response.UserId = applicant.Id;
        response.About = applicant.About;
        return response;
    }

    public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        Applicant applicant = await _repository.Get(a => a.Id == request.UserId);
        applicant.Id = request.UserId;
        applicant.About = request.About;
        await _repository.Update(applicant);

        UpdateApplicantResponse response = new UpdateApplicantResponse();
        response.UserId = applicant.Id;
        response.About = applicant.About;
        return response;

    }
}
