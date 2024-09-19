using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Dealoviy.Application.ContractorProfiles.Commands.Update;

public class UpdateContractorProfileCommandHandler 
    : IRequestHandler<UpdateContractorProfileCommand, ErrorOr<Unit>>
{
    private readonly IContractorProfileRepository _contractorProfileRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateContractorProfileCommandHandler(
        IContractorProfileRepository contractorProfileRepository, 
        IUserRepository userRepository,
        IMapper mapper)
    {
        _contractorProfileRepository = contractorProfileRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateContractorProfileCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.UserId)
            is not User user)
        {
            return Errors.UserNotFound;
        }
        
        if(user.ContractorProfileId is null ||
            await _contractorProfileRepository.GetByIdAsync(user.ContractorProfileId.Value)
            is not ContractorProfile profile)
        {
            return Errors.ContractorProfileNotFound;
        }
        
        var contractorProfileResult = profile.Update(
            request.AdditionalInfo,
            _mapper.Map<List<ContactInfoCreateModel>>(request.ContactInfos)
        );

        if (contractorProfileResult.IsError)
        {
            return contractorProfileResult.Errors;
        }
        
        var contractorProfile = contractorProfileResult.Value;
        
        await _contractorProfileRepository.UpdateAsync(contractorProfile);

        return Unit.Value;
    }
}