using Dealoviy.Domain.Common.ContactInfo;
using ErrorOr;

namespace Dealoviy.Domain.Requests;

public class Request
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid ServiceId { get; private set; }
    public string Description { get; private set; }
    public int PaymentAmount { get; private set; }
    public DateTime RequestDate { get; private set; }
    public RequestStatus RequestStatus { get; private set; }
    public ContactInfo CustomerContactInfo { get; private set; }
    public ContactInfo ContractorContactInfo { get; private set; }

    public static ErrorOr<Request> Create(
        Guid customerId,
        Guid serviceId,
        string description,
        int paymentAmount,
        DateTime requestDate,
        RequestStatus requestStatus,
        ContactInfoCreateModel customerContactInfo,
        ContactInfo contractorContactInfo)
    {
        var customerContactInfoResult = ContactInfo.Create(customerContactInfo);
        if (customerContactInfoResult.IsError)
        {
            return customerContactInfoResult.Errors;
        }
        
        
        return new Request(
            customerId,
            serviceId,
            description,
            paymentAmount,
            requestDate,
            requestStatus,
            customerContactInfoResult.Value,
            contractorContactInfo);
    }
    
    public void UpdateRequestStatus(RequestStatus requestStatus)
    {
        RequestStatus = requestStatus;
    }
    
    private Request(
        Guid customerId, 
        Guid serviceId, 
        string description, 
        int paymentAmount, 
        DateTime requestDate, 
        RequestStatus requestStatus, 
        ContactInfo customerContactInfo, 
        ContactInfo contractorContactInfo)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        ServiceId = serviceId;
        Description = description;
        PaymentAmount = paymentAmount;
        RequestDate = requestDate;
        RequestStatus = requestStatus;
        CustomerContactInfo = customerContactInfo;
        ContractorContactInfo = contractorContactInfo;
    }
    
    private Request() {}
}