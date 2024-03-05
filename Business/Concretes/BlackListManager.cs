using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.BlackList;
using Business.Responses.BlackList;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Business.Concretes;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository _blacklistRepository;
    private readonly IMapper _mapper;
    private readonly BlacklistBusinessRules _rules;

    public BlackListManager(IBlackListRepository blacklistRepository, IMapper mapper, BlacklistBusinessRules blacklistBusinessRules)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
        _rules = blacklistBusinessRules;
    }
    public async Task<IDataResult<CreateBlackListResponse>> AddAsync(CreateBlackListRequest request)
    {
        BlackList blacklist = _mapper.Map<BlackList>(request);
        await _blacklistRepository.AddAsync(blacklist);
        CreateBlackListResponse response = _mapper.Map<CreateBlackListResponse>(blacklist);
        return new SuccessDataResult<CreateBlackListResponse>(response, BlackListMessages.BlackListAdded);
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> ApplicantBlacklistAsync(int applicantId)
    {
        BlackList blackList = await _blacklistRepository.GetAsync(x => x.ApplicantId == applicantId);
        GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blackList);
        return new SuccessDataResult<GetByIdBlackListResponse>(response);
    }

    public async Task<IResult> DeleteAsync(DeleteBlackListRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id,request.Id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == request.Id);
        await _blacklistRepository.DeleteAsync(blacklist);
        return new SuccessResult(BlackListMessages.BlackListDeleted);
    }
    public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
    {
        List<BlackList> blacklists = await _blacklistRepository.GetAllAsync(include: x => x.Include(x => x.Applicant));
        List<GetAllBlackListResponse> responses = _mapper.Map<List<GetAllBlackListResponse>>(blacklists);
        return new SuccessDataResult<List<GetAllBlackListResponse>>(responses, BlackListMessages.BlackListGetAll);
    }
    public async Task<GetByIdBlackListResponse> GetByApplicantId(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant));
        GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blacklist);
        return response;
    }
    public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant));
        GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blacklist);
        return new SuccessDataResult<GetByIdBlackListResponse>(response, BlackListMessages.BlackListGetById);
    }
    public async Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        BlackList blacklist = await _blacklistRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Applicant));
        blacklist = _mapper.Map(request, blacklist);
        await _blacklistRepository.UpdateAsync(blacklist);
        UpdateBlackListResponse response = _mapper.Map<UpdateBlackListResponse>(blacklist);
        return new SuccessDataResult<UpdateBlackListResponse>(response, BlackListMessages.BlackListUpdated);
    }
}
