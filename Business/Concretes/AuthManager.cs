﻿using Business.Abstracts;
using Business.Dtos;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Entities.Concrates;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly UserBusinessRules _userBusinessRules;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository,
        IEmployeeRepository employeeRepository, IInstructorRepository instructorRepository, IApplicantRepository applicantRepository, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
        _instructorRepository = instructorRepository;
        _applicantRepository = applicantRepository;
        _userBusinessRules = userBusinessRules;
    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(Employee employee)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == employee.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(employee, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(Instructor instructor)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == instructor.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(instructor, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(Applicant applicant)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == applicant.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(applicant, claims);
        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }
    public async Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
    {
        var user = await _userService.GetByMail(userForLoginDto.Email);
        await _userBusinessRules.UserShouldBeExists(user.Data);
        await _userBusinessRules.UserEmailShouldBeExists(userForLoginDto.Email);
        await _userBusinessRules.UserPasswordShouldBeMatch(user.Data.Id, userForLoginDto.Password);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }
    public async Task<DataResult<AccessToken>> RegisterEmployee(EmployeeForRegisterDto employeeForRegisterDto)
    {
        await _userBusinessRules.UserEmailShouldBeNotExists(employeeForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(employeeForRegisterDto.Password, out passwordHash, out passwordSalt);
        var employee = new Employee
        {
            Email = employeeForRegisterDto.Email,
            FirstName = employeeForRegisterDto.FirstName,
            LastName = employeeForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Position = employeeForRegisterDto.Position,
            NationalIdentity = employeeForRegisterDto.NationalIdentity,
            DateOfBirth = employeeForRegisterDto.DateOfBirth,
            UserName = employeeForRegisterDto.UserName,
        };
        await _employeeRepository.AddAsync(employee);
        var createAccessToken = await CreateAccessToken(employee);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Employee registered successfully");
    }
    public async Task<DataResult<AccessToken>> RegisterApplicant(ApplicantForRegisterDto applicantForRegisterDto)
    {
        await _userBusinessRules.UserEmailShouldBeNotExists(applicantForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(applicantForRegisterDto.Password, out passwordHash, out passwordSalt);
        var applicant = new Applicant
        {
            Email = applicantForRegisterDto.Email,
            FirstName = applicantForRegisterDto.FirstName,
            LastName = applicantForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            About = applicantForRegisterDto.About,
            NationalIdentity = applicantForRegisterDto.NationalIdentity,
            DateOfBirth = applicantForRegisterDto.DateOfBirth,
            UserName = applicantForRegisterDto.UserName,
        };
        await _applicantRepository.AddAsync(applicant);
        var createAccessToken = await CreateAccessToken(applicant);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Applicant registered successfully");
    }
    public async Task<DataResult<AccessToken>> RegisterInstructor(InstructorForRegisterDto instructorForRegisterDto)
    {
        await _userBusinessRules.UserEmailShouldBeNotExists(instructorForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(instructorForRegisterDto.Password, out passwordHash, out passwordSalt);
        var instructor = new Instructor
        {
            Email = instructorForRegisterDto.Email,
            FirstName = instructorForRegisterDto.FirstName,
            LastName = instructorForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CompanyName = instructorForRegisterDto.CompanyName,
            NationalIdentity = instructorForRegisterDto.NationalIdentity,
            DateOfBirth = instructorForRegisterDto.DateOfBirth,
            UserName = instructorForRegisterDto.UserName,
        };
        await _instructorRepository.AddAsync(instructor);
        var createAccessToken = await CreateAccessToken(instructor);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Instructor registered successfully");
    }
}

