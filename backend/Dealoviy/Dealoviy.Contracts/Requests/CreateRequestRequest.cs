using Dealoviy.Contracts.Common;

namespace Dealoviy.Contracts.Requests;

public record CreateRequestRequest(
    string Description,
    ContactInfoRequest CustomerContactInfo,
    int PaymentAmount);