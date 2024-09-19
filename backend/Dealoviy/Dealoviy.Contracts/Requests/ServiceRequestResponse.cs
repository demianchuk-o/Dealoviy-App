using Dealoviy.Contracts.Common;

namespace Dealoviy.Contracts.Requests;

public record ServiceRequestResponse(
    Guid RequestId,
    string Description,
    int PaymentAmount,
    DateTime RequestDate,
    string RequestStatus,
    string CustomerName,
    ContactInfoResponse CustomerContactInfo
    );