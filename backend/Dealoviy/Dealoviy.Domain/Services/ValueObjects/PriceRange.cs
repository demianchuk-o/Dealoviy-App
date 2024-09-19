using Dealoviy.Domain.Common.Errors;
using ErrorOr;

namespace Dealoviy.Domain.Services.ValueObjects;

public record PriceRange
{
    public int Lower { get; init; }
    public int Upper { get; init; }
    
    public static ErrorOr<PriceRange> Create(int lower, int upper)
    {
        if (lower < 0 || upper < 0)
        {
            return Errors.NegativePriceRange;
        }
        
        if (lower > upper)
        {
            return Errors.LowerBoundGreaterThanUpperBound;
        }
        
        return new PriceRange(lower, upper);
    }
    
    private PriceRange(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
    }
}