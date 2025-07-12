using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Keywords.Dtos;

namespace Cut_Roll_Movies.Core.Keywords.Repositories;

public interface IKeywordRepository : IDeleteByIdAsync<int, int?>, ICreateAsync<KeywordCreateDto, int>
{
    
}
