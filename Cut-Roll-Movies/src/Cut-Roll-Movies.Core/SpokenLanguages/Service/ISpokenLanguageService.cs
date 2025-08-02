namespace Cut_Roll_Movies.Core.SpokenLanguages.Service;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.SpokenLanguages.Dtos;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;

public interface ISpokenLanguageService
{
    Task<PagedResult<SpokenLanguage>> GetAllSpokenLanguageAsync(SpokenLanguagePaginationDto dto);
    Task<PagedResult<SpokenLanguage>> SearchSpokenLanguageByNameAsync(SpokenLanguageSearchByNameDto dto);
    Task<SpokenLanguage?> GetSpokenLanguageByIsoCodeAsync(string? isoCode);
}
