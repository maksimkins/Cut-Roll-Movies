using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.People.Dtos;
using Cut_Roll_Movies.Core.People.Models;

namespace Cut_Roll_Movies.Core.People.Repositories;

public interface IPersonRepository : ISearchAsync<PersonSearchRequest, PagedResult<Person>>, IGetByIdAsync<Guid, Person?>, IUpdateAsync<PersonUpdateDto, Guid?>,
IDeleteByIdAsync<Guid, Guid?>, ICreateAsync<PersonCreateDto, Guid?>
{
    Task<IEnumerable<Movie>> GetFilmographyAsync(MovieSearchByPesonIdDto searchByPersonIdDto);
}
