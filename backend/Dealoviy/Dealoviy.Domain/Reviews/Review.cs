namespace Dealoviy.Domain.Reviews;

public class Review
{
    public Guid Id { get; private set; }
    public Guid ServiceId { get; private set; }
    public Guid UserId { get; private set; }
    public int Rating { get; private set; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public static Review Create(
        Guid serviceId,
        Guid userId,
        int rating,
        string text,
        DateTime createdAt)
    {
        return new Review(serviceId, userId, rating, text, createdAt);
    }
    
    private Review(
        Guid serviceId,
        Guid userId,
        int rating,
        string text,
        DateTime createdAt)
    {
        Id = Guid.NewGuid();
        ServiceId = serviceId;
        UserId = userId;
        Rating = rating;
        Text = text;
        CreatedAt = createdAt;
    }
    private Review() { }
}