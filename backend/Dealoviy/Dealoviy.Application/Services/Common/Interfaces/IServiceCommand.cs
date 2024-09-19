namespace Dealoviy.Application.Services.Common.Interfaces;

public interface IServiceCommand
{
    Guid CityId { get; }
    string Name { get; }
    string Description { get; }
    int LowerPriceBound { get; }
    int UpperPriceBound { get; }
}