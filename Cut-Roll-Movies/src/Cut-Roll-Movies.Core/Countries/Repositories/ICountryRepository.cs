namespace Cut_Roll_Movies.Core.Countries.Repositories;

using Cut_Roll_Movies.Core.Countries.Models;

public interface ICountryRepository 
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<IEnumerable<Country>> SearchByNameAsync(string name);
    Task<Country?> GetByIsoCodeAsync(string isoCode);
}
