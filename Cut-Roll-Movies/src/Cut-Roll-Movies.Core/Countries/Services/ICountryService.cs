namespace Cut_Roll_Movies.Core.Countries.Services;

using Cut_Roll_Movies.Core.Countries.Models;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<IEnumerable<Country>> SearchCountryByNameAsync(string name);
    Task<Country?> GetCountryByIsoCodeAsync(string isoCode);
}
