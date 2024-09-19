using ErrorOr;

namespace Dealoviy.Domain.Common.Errors;

public static partial class Errors
{
    public static Error UserIsNotAContractor 
        => Error.Conflict("User.IsNotAContractor", "User is not a contractor");
    public static Error ContractorProfileNotFound 
        => Error.NotFound("ContractorProfile.NotFound", "Contractor profile not found");
}