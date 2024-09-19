using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.ContractorProfiles.Queries.Common;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Users;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.ContractorProfiles.Queries.GetById;

public class GetContractorProfileByIdQueryHandler 
    : IRequestHandler<GetContractorProfileByIdQuery, ErrorOr<ContractorProfileResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;

    public GetContractorProfileByIdQueryHandler(IUserRepository userRepository, IContractorProfileRepository contractorProfileRepository)
    {
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
    }

    public async Task<ErrorOr<ContractorProfileResult>> Handle(
        GetContractorProfileByIdQuery request, 
        CancellationToken cancellationToken)
    {
        if (await _contractorProfileRepository.GetByIdAsync(request.Id) is not ContractorProfile profile)
        {
            return Errors.ContractorProfileNotFound;
        }
        
        if (await _userRepository.GetByContractorIdAsync(request.Id) is not User user)
        {
            return Errors.UserNotFound;
        }
        
        return new ContractorProfileResult(
            profile.Id,
            user.GetDisplayName(),
            profile.AdditionalInfo,
            profile.ContactInfos.
                Select(ct => ct.Type.ToString()).ToArray());
    }
}