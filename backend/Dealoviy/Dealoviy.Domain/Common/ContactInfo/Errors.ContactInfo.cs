using Dealoviy.Domain.Common.ContactInfo;
using ErrorOr;

namespace Dealoviy.Domain.Common.Errors;

public partial class Errors
{
    public static Error InvalidContactInfoType(string type)
        => Error.Validation("Validation.ContactInfo.Type.Invalid", 
            $"Contact info type '{type}' is invalid");
    
    public static Error InvalidPhoneNumber(ContactInfoType type)
        => Error.Validation("Validation.ContactInfo.Value.InvalidPhoneNumber", 
        $"Contact info value of {type} is not a valid phone number");
    
    
    public static Error InvalidUserHandle(ContactInfoType type)
        => Error.Validation("Validation.ContactInfo.Value.InvalidUserHandle", 
            $"Contact info value of type {type} is not a valid user handle");
}