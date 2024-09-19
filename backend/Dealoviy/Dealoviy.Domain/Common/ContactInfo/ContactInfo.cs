using ErrorOr;

namespace Dealoviy.Domain.Common.ContactInfo;

public record ContactInfo
{
    public ContactInfoType Type { get; }
    public string Value { get; }
    private ContactInfo(ContactInfoType type, string value)
    {
        Type = type;
        Value = value;
    }
    
    public static ErrorOr<ContactInfo> Create(ContactInfoCreateModel model)
    {
        if (!Enum.TryParse<ContactInfoType>(model.Type, out var type))
        {
            return Errors.Errors.InvalidContactInfoType(model.Type);
        }

        return type switch
        {
            ContactInfoType.Phone 
                or ContactInfoType.Viber
                or ContactInfoType.WhatsApp 
                when !IsValidPhoneNumber(model.Value)
                => Errors.Errors.InvalidPhoneNumber(type),
            ContactInfoType.Telegram
                when !IsValidUserHandle(model.Value)
                => Errors.Errors.InvalidUserHandle(type),
            _ => new ContactInfo(type, model.Value)
        };
    }
    
    private static bool IsValidPhoneNumber(string value)
        => value.All(char.IsDigit)
            && value.Length == 12
            && value.StartsWith("380");
    
    private static bool IsValidUserHandle(string value)
        => value.StartsWith('@');
};