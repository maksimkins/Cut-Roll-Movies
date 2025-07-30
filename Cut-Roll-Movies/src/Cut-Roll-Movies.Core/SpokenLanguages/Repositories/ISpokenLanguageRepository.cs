namespace Cut_Roll_Movies.Core.SpokenLanguages.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;

public interface ISpokenLanguageRepository
{
    Task<IEnumerable<SpokenLanguage>> GetAllAsync();
    Task<IEnumerable<SpokenLanguage>> SearchByNameAsync(string name);
    Task<SpokenLanguage?> GetByIsoCodeAsync(string isoCode);
}
