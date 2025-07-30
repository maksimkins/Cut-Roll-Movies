namespace Cut_Roll_Movies.Core.SpokenLanguages.Service;

using Cut_Roll_Movies.Core.SpokenLanguages.Models;

public interface ISpokenLanguageService
{
    Task<IEnumerable<SpokenLanguage>> GetAllSpokenLanguageAsync();
    Task<IEnumerable<SpokenLanguage>> SearchSpokenLanguageByNameAsync(string name);
    Task<SpokenLanguage?> GetSpokenLanguageByIsoCodeAsync(string isoCode);
}
