namespace Dealoviy.Domain.Common.Location;

public class Region
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public static Region Create(string name)
    {
        return new Region(name);
    }
    
    private Region(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}