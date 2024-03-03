using Business.Requests.BlackList;
using Business.Responses.BlackList;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBlackListService
{
        Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request);
        Task<IResult> DeleteAsync(DeleteBlackListRequest request);
        Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request);
        Task<GetByIdBlackListResponse> GetByApplicantId(int id);
}
