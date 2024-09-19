using Dealoviy.Contracts.Common;

namespace Dealoviy.Contracts.Orders;

public record ServiceOrderResponse(
    Guid OrderId,
    string Description,
    int PaymentAmount,
    DateTime RequestDate,
    string OrderStatus,
    string CustomerName,
    ContactInfoResponse CustomerContactInfo
    );