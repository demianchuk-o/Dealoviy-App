namespace Dealoviy.Contracts.Reviews;

public record CreateReviewRequest(
    string ReviewText,
    int Rating);