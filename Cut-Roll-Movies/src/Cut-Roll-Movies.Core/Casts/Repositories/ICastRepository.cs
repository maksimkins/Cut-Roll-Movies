using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

namespace Cut_Roll_Movies.Core.Casts.Repositories;

public interface ICastRepository : IGetByIdAsync<Cast?, Guid>, IUpdateAsync<CastUpdateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>, ICreateAsync<CastUpdateDto, Guid>
{
    
}
