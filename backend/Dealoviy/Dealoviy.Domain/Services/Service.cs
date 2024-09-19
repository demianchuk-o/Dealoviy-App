using Dealoviy.Domain.Services.ValueObjects;
using ErrorOr;

namespace Dealoviy.Domain.Services;

public class Service
{
    public Guid Id { get; private set; }
    public Guid ContractorId { get; private set; }
    public Guid CityId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public PriceRange PriceRange { get; private set; }
    public AverageRating AverageRating { get; private set; } = new();
    
    public static ErrorOr<Service> Create(
        Guid contractorId,
        Guid cityId,
        string name,
        string description,
        int lowerPriceBound,
        int upperPriceBound)
    {
        var priceRange = PriceRange.Create(lowerPriceBound, upperPriceBound);
        
        if (priceRange.IsError)
        {
            return priceRange.Errors;
        }
        
        return new Service(
            contractorId, 
            cityId, 
            name, 
            description, 
            priceRange.Value);
    }
    
    public ErrorOr<Service> Update(
        Guid cityId,
        string name,
        string description,
        int lowerPriceBound,
        int upperPriceBound)
    {
        var priceRange = PriceRange.Create(lowerPriceBound, upperPriceBound);
        
        if (priceRange.IsError)
        {
            return priceRange.Errors;
        }
        
        CityId = cityId;
        Name = name;
        Description = description;
        PriceRange = priceRange.Value;
        
        return this;
    }
    
    private Service(
        Guid contractorId,
        Guid cityId,
        string name,
        string description,
        PriceRange priceRange)
    {
        Id = Guid.NewGuid();
        ContractorId = contractorId;
        CityId = cityId;
        Name = name;
        Description = description;
        PriceRange = priceRange;
    }
    
    private Service() {}
}