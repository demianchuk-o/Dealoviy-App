namespace Dealoviy.Domain.Services.ValueObjects;

public class AverageRating
{
    public double Value { get; private set; } = 0;
    public int Count { get; private set; } = 0;
    
    public void AddRating(int rating)
    {
        Value = (Value * Count + rating) / (Count + 1);
        Count++;
    }
    
    public void RemoveRating(int rating)
    {
        if (Count == 0)
        {
            return;
        }
        
        Value = (Value * Count - rating) / (Count - 1);
        Count--;
    }
}