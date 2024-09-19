using Dealoviy.Contracts.Common;

namespace Dealoviy.Contracts.Orders;

public record UserOrderResponse(Guid RequestId,
    string Description,
    int PaymentAmount,
    DateTime RequestDate,
    string OrderStatus,
    string ContractorName,
    Guid ServiceId,
    string ServiceName,
    ContactInfoResponse ContractorContactInfo
    );