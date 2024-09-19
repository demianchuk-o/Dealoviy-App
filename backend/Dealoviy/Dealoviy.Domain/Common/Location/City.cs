namespace Dealoviy.Domain.Common.Location;

public class City
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid RegionId { get; private set; }
    
    public static City Create(string name, Guid regionId)
    {
        return new City(name, regionId);
    }

    private City(string name, Guid regionId)
    {
        Id = Guid.NewGuid();
        Name = name;
        RegionId = regionId;
    }
}