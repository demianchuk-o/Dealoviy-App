using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Dealoviy.Domain.Common.Location;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence;

public static class ModelBuilderExtensions
{
    public static void SeedLocationData(this ModelBuilder builder)
    {
        var locationCsvPath = FilePathBuilder.GetDataFilePath("ua.csv");
        
        using var streamReader = new StreamReader(locationCsvPath, Encoding.UTF8);
        streamReader.BaseStream.Position = 0;
        
        using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        });
        
        var regions = new HashSet<Region>();
        var cities = new List<City>();
        
        csvReader.Read();
        csvReader.ReadHeader();
        
        while (csvReader.Read())
        {
            var regionName = csvReader.GetField("admin_name");

            var region = regions.FirstOrDefault(r => r.Name == regionName);
            if (region is null)
            {
                region = Region.Create(regionName);
                regions.Add(region);
            }
            
            var cityName = csvReader.GetField("city");
            
            var city = City.Create(cityName, region.Id);
            cities.Add(city);
            
        }
        
        builder.Entity<Region>().HasData(regions);
        
        builder.Entity<City>().HasData(cities);
    }
}