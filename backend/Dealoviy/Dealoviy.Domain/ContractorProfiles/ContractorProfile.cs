using Dealoviy.Domain.Common.ContactInfo;
using ErrorOr;

namespace Dealoviy.Domain.ContractorProfiles;

public class ContractorProfile
{
    public Guid Id { get; private set; }
    public string AdditionalInfo { get; private set; }
    public List<ContactInfo> ContactInfos { get; private set; }

    public static ErrorOr<ContractorProfile> Create(
        string additionalInfo,
        List<ContactInfoCreateModel> contactInfos)
    {
        var contactInfoResult = ValidateAndCreateContactInfos(contactInfos);
        
        if (contactInfoResult.IsError)
        {
            return contactInfoResult.Errors;
        }
        
        return new ContractorProfile(additionalInfo, contactInfoResult.Value);
    }
    
    public  ErrorOr<ContractorProfile> Update(
        string additionalInfo,
        List<ContactInfoCreateModel> contactInfos)
    {
        var contactInfoResult = ValidateAndCreateContactInfos(contactInfos);
        
        if (contactInfoResult.IsError)
        {
            return contactInfoResult.Errors;
        }
        
        AdditionalInfo = additionalInfo;
        ContactInfos = contactInfoResult.Value;
        
        return this;
    }
    
    private ContractorProfile(
        string additionalInfo,
        List<ContactInfo> contactInfos)
    {
        Id = Guid.NewGuid();
        AdditionalInfo = additionalInfo;
        ContactInfos = contactInfos;
    }
    
    private ContractorProfile() {}
    
    private static ErrorOr<List<ContactInfo>> ValidateAndCreateContactInfos(
        List<ContactInfoCreateModel> contactInfos)
    {
        if (!contactInfos.Any())
        {
            return Error.Validation("ContactInfos.Empty", "Contractor profile must have at least one contact info");
        }
        
        var contactInfoModels = contactInfos.Select(
            cim => ContactInfo.Create(cim));
        
        var contactInfoErrors = contactInfoModels
            .Where(cim => cim.IsError);

        if (contactInfoErrors.Any())
        {
            return contactInfoErrors.Select(cie => cie.FirstError)
                .ToList();
        }
        
        var contactInfoValues = contactInfoModels
            .Select(cim => cim.Value)
            .ToList();

        return contactInfoValues;
    }
}