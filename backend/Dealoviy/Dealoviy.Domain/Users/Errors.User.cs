using ErrorOr;

namespace Dealoviy.Domain.Common.Errors;

public static partial class Errors
{
    public static Error DuplicateUsername => Error.Conflict(
        code: "User.DuplicateUsername",
        description: "Username is already in use");

    public static Error UserNotFound => Error.NotFound(
        code: "User.NotFound",
        description: "User was not found");
}