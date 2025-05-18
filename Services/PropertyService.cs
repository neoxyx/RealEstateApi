using MongoDB.Driver;
using RealEstateApi.Models;
using RealEstateApi.Interfaces;
using Microsoft.Extensions.Options;
using RealEstateApi.Dtos;

namespace RealEstateApi.Services;

public class PropertyService : IPropertyService
{
    private readonly IMongoCollection<Property> _properties;

    public PropertyService(IOptions<MongoDBSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _properties = mongoDatabase.GetCollection<Property>(settings.Value.PropertiesCollectionName);
    }

    public async Task<List<Property>> GetFilteredAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
    {
        var filterBuilder = Builders<Property>.Filter;
        var filters = new List<FilterDefinition<Property>>();

        if (!string.IsNullOrEmpty(name))
            filters.Add(filterBuilder.Regex(p => p.name, new MongoDB.Bson.BsonRegularExpression(name, "i")));

        if (!string.IsNullOrEmpty(address))
            filters.Add(filterBuilder.Regex(p => p.addressProperty, new MongoDB.Bson.BsonRegularExpression(address, "i")));

        if (minPrice.HasValue)
            filters.Add(filterBuilder.Gte(p => p.priceProperty, minPrice.Value));

        if (maxPrice.HasValue)
            filters.Add(filterBuilder.Lte(p => p.priceProperty, maxPrice.Value));

        var finalFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

        return await _properties.Find(finalFilter).ToListAsync();
    }

    public async Task<List<Property>> GetAsync() =>
        await _properties.Find(_ => true).ToListAsync();

    public async Task<Property?> GetAsync(string _id) =>
        await _properties.Find(p => p._id == _id).FirstOrDefaultAsync();

    private static PropertyDto MapToDto(Property property)
    {
        return new PropertyDto
        {
            _id = property._id,
            idOwner = property.idOwner,
            name = property.name,
            addressProperty = property.addressProperty,
            priceProperty = property.priceProperty,
            image = property.image
        };
    }

}
