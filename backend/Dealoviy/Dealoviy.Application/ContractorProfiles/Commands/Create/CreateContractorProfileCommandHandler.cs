using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Dealoviy.Application.ContractorProfiles.Commands.Create;

public class CreateContractorProfileCommandHandler : IRequestHandler<CreateContractorProfileCommand, ErrorOr<Unit>>
{
    private readonly IContractorProfileRepository _contractorProfileRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateContractorProfileCommandHandler(
        IContractorProfileRepository contractorProfileRepository, 
        IUserRepository userRepository,
        IMapper mapper)
    {
        _contractorProfileRepository = contractorProfileRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateContractorProfileCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.UserId)
            is not User user)
        {
            return Errors.UserNotFound;
        }
        
        var contractorProfileResult = ContractorProfile.Create(
            request.AdditionalInfo,
            _mapper.Map<List<ContactInfoCreateModel>>(request.ContactInfos)
        );

        if (contractorProfileResult.IsError)
        {
            return contractorProfileResult.Errors;
        }
        
        var contractorProfile = contractorProfileResult.Value;
        
        await _contractorProfileRepository.AddAsync(contractorProfile);

        user.SetContractorProfileId(contractorProfile.Id);
        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}