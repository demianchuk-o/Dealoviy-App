using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.Requests;

namespace Dealoviy.Domain.Orders;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid ServiceId { get; private set; }
    public string Description { get; private set; }
    public int PaymentAmount { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public ContactInfo CustomerContactInfo { get; private set; }
    public ContactInfo ContractorContactInfo { get; private set; }
    
    public static Order Create(Request request, DateTime orderDate)
    {
        return new Order(
            request.CustomerId,
            request.ServiceId,
            request.Description,
            request.PaymentAmount,
            orderDate,
            request.CustomerContactInfo,
            request.ContractorContactInfo);
    }
    
    public void UpdateOrderStatus(OrderStatus orderStatus)
    {
        OrderStatus = orderStatus;
    }
    private Order(
        Guid customerId, 
        Guid serviceId, 
        string description, 
        int paymentAmount,
        DateTime orderDate,
        ContactInfo customerContactInfo, 
        ContactInfo contractorContactInfo)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        ServiceId = serviceId;
        Description = description;
        PaymentAmount = paymentAmount;
        OrderDate = orderDate;
        OrderStatus = OrderStatus.NotStarted;
        CustomerContactInfo = customerContactInfo;
        ContractorContactInfo = contractorContactInfo;
    }
    
    private Order() { }
}