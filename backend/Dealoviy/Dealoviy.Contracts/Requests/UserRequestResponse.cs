using Dealoviy.Contracts.Common;

namespace Dealoviy.Contracts.Requests;

public record UserRequestResponse(
    Guid RequestId,
    string Description,
    int PaymentAmount,
    DateTime RequestDate,
    string RequestStatus,
    string ContractorName,
    Guid ServiceId,
    string ServiceName,
    ContactInfoResponse ContractorContactInfo
    );