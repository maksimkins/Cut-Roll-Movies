namespace Cut_Roll_Movies.Core.People.Service;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.People.Dtos;
using Cut_Roll_Movies.Core.People.Models;

public interface IPersonService
{
    Task<PagedResult<Person>> SearchPersonAsync(PersonSearchRequest? request);
    Task<Person?> GetPersonByIdAsync(Guid? id);
    Task<Guid> UpdatePersonAsync(PersonUpdateDto? dto);
    Task<Guid> DeletePersonByIdAsync(Guid? id);
    Task<Guid> CreatePersonAsync(PersonCreateDto? dto);
    Task<PagedResult<Movie>> GetFilmographyAsync(MovieSearchByPesonIdDto? searchByPersonIdDto);


}

