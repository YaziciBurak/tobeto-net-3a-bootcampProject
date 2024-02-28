using AutoMapper;
using Business.Abstracts;
using Business.Requests.BlackList;
using Business.Responses.BlackList;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository _blacklistRepository;
    private readonly IMapper _mapper;

    public BlackListManager(IBlackListRepository blacklistRepository, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request)
    {
        BlackList blacklist = _mapper.Map<BlackList>(request);
        await _blacklistRepository.AddAsync(blacklist);

        CreateBlackListResponse response = _mapper.Map<CreateBlackListResponse>(blacklist);
        return new SuccessDataResult<CreateBlackListResponse>(response, "Ekleme İşlemi Başarılı");
    }

    public async Task<IResult> DeleteAsync(DeleteBlackListRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == request.Id);
        await _blacklistRepository.DeleteAsync(blacklist);
        return new SuccessResult("Silme İşlemi Başarılı");
    }

    public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
    {
        List<BlackList> blacklists = await _blacklistRepository.GetAllAsync(include: x => x.Include(x => x.Applicant));
        List<GetAllBlackListResponse> responses = _mapper.Map<List<GetAllBlackListResponse>>(blacklists);
        return new SuccessDataResult<List<GetAllBlackListResponse>>(responses, "Listeleme İşlemi Başarılı");
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id)
    {
        await CheckIfIdNotExists(id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant));
        GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blacklist);
        return new SuccessDataResult<GetByIdBlackListResponse>(response, "GetById İşlemi Başarılı");
    }

    public async Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Applicant));
        blacklist = _mapper.Map(request, blacklist);
        await _blacklistRepository.UpdateAsync(blacklist);
        UpdateBlackListResponse response = _mapper.Map<UpdateBlackListResponse>(blacklist);
        return new SuccessDataResult<UpdateBlackListResponse>(response, "Güncelleme İşlemi Başarılı");
    }
    private async Task CheckIfIdNotExists(int blacklistId)
    {
        var isExists = await _blacklistRepository.GetAsync(blacklist => blacklist.Id == blacklistId);
        if (isExists is null) throw new BusinessException("Id not exists");

    }
}
