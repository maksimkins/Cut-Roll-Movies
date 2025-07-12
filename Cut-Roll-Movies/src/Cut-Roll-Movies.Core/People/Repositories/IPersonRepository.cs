using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.People.Dtos;
using Cut_Roll_Movies.Core.People.Models;

namespace Cut_Roll_Movies.Core.People.Repositories;

public interface IPersonRepository : ISearchAsync<PagedResult<Person>, PersonSearchRequest>, IGetByIdAsync<Person?, int>, IUpdateAsync<PersonUpdateDto, int?>, IDeleteByIdAsync<int, int?>, ICreateAsync<PersonCreateDto, int>
{
    
}
