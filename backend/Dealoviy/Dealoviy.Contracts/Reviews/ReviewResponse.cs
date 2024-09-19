namespace Dealoviy.Contracts.Reviews;

public record ReviewResponse(
    Guid ReviewId,
    string ReviewerName,
    string ReviewText,
    DateTime ReviewDate,
    int Rating
    );