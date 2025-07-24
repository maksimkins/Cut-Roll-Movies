using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.People.Dtos;
using Cut_Roll_Movies.Core.People.Models;

namespace Cut_Roll_Movies.Core.People.Repositories;

public interface IPersonRepository : ISearchAsync<PagedResult<Person>, PersonSearchRequest>, IGetByIdAsync<Person?, Guid>, IUpdateAsync<PersonUpdateDto, Guid?>,
IDeleteByIdAsync<Guid, Guid?>, ICreateAsync<PersonCreateDto, Guid>
{
    
}
