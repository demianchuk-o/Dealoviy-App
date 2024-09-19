using ErrorOr;

namespace Dealoviy.Domain.Common.Errors;

public partial class Errors
{
    public static Error CityNotFound =>
        Error.NotFound("City.NotFound", $"City was not found");
}