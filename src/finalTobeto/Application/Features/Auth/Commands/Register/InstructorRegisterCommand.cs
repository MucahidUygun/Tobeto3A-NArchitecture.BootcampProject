using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class InstructorRegisterCommand : IRequest<RegisteredResponse>
{
    public InstructorForRegisterDto InstructorForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public InstructorRegisterCommand()
    {
        InstructorForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public InstructorRegisterCommand(InstructorForRegisterDto instructorForRegisterDto, string ipAddress)
    {
        InstructorForRegisterDto = instructorForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<InstructorRegisterCommand, RegisteredResponse>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(
            IInstructorRepository instructorRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules
        )
        {
            _instructorRepository = instructorRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisteredResponse> Handle(InstructorRegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.InstructorForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.InstructorForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            Instructor newInstructor =
                new()
                {
                    Email = request.InstructorForRegisterDto.Email,
                    CompanyName = request.InstructorForRegisterDto.CompanyName,
                    FirstName = request.InstructorForRegisterDto.FirstName,
                    LastName = request.InstructorForRegisterDto.LastName,
                    DateOfBirth = request.InstructorForRegisterDto.DateOfBirth,
                    NationalIdentity = request.InstructorForRegisterDto.NationalIdentity,
                    UserName = request.InstructorForRegisterDto.UserName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            Instructor createdInstructor = await _instructorRepository.AddAsync(newInstructor);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdInstructor);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
                createdInstructor,
                request.IpAddress
            );
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}