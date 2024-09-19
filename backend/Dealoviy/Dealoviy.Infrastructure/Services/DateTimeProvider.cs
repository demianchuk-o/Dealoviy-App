using Dealoviy.Application.Common.Interfaces.Services;

namespace Dealoviy.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}