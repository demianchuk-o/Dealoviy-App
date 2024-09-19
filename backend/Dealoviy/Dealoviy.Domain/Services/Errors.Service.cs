using ErrorOr;

namespace Dealoviy.Domain.Common.Errors;

public static partial class Errors
{
    public static Error NegativePriceRange =>
        Error.Validation("Validation.Service.NegativePriceRange", 
            "Price range cannot be negative");
    
    public static Error LowerBoundGreaterThanUpperBound =>
        Error.Validation("Validation.Service.LowerBoundGreaterThanUpperBound", 
            "Lower bound cannot be greater than upper bound");
    
    public static Error ServiceNotFound =>
        Error.NotFound("Service not found");
}