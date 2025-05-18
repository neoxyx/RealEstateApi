using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Models;
using RealEstateApi.Services;
using RealEstateApi.Dtos;

namespace RealEstateApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyService _propertyService;

    public PropertyController(PropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PropertyDto>>> Get(
    [FromQuery] string? name,
    [FromQuery] string? address,
    [FromQuery] decimal? minPrice,
    [FromQuery] decimal? maxPrice)
    {
        try
        {
            var properties = await _propertyService.GetFilteredAsync(name, address, minPrice, maxPrice);

            var dtoList = properties.Select(p => MapToDto(p)).ToList();

            return Ok(dtoList);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR en Get /api/Property: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    private PropertyDto MapToDto(Property property)
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
