namespace Dealoviy.Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string? DisplayName { get; private set; } = null;
    public string PasswordHash { get; private set; }

    public Guid? ContractorProfileId { get; private set; } = null;
    
    public static User Create(string username, string? displayName, string passwordHash)
    {
        return new User(username, displayName, passwordHash);
    }
    
    public User Update(string? displayName)
    {
        DisplayName = (string.IsNullOrWhiteSpace(displayName))
            ? null
            : displayName;
        return this;
    }
    
    private User(string username, string? displayName, string passwordHash)
    {
        Id = Guid.NewGuid();
        Username = username;
        DisplayName = (string.IsNullOrWhiteSpace(displayName))
            ? null
            : displayName;
        PasswordHash = passwordHash;
    }
    
    public void SetContractorProfileId(Guid contractorProfileId)
    {
        ContractorProfileId = contractorProfileId;
    }
    
    public string GetDisplayName()
    {
        return DisplayName ?? Username;
    }
    private User() {}
}