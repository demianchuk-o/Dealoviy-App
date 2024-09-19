namespace Dealoviy.Contracts.Services;

public record ServiceTaskStatResponse(
    Guid ServiceId,
    string ServiceName,
    int PendingRequestsCount,
    int NotFinishedOrdersCount
    );