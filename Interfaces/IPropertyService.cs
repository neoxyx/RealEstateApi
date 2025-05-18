using RealEstateApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateApi.Interfaces
{
    public interface IPropertyService
    {
        Task<List<Property>> GetFilteredAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
    }
}
