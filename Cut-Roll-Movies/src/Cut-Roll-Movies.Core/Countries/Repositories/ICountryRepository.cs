namespace Cut_Roll_Movies.Core.Countries.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Countries.Dtos;
using Cut_Roll_Movies.Core.Countries.Models;

public interface ICountryRepository 
{
    Task<PagedResult<Country>> GetAllAsync(ContryPaginationDto dto);
    Task<PagedResult<Country>> SearchByNameAsync(ContrySearchByNameDto dto);
    Task<Country?> GetByIsoCodeAsync(string isoCode);
}
