using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieKeywords.Dtos;

namespace Cut_Roll_Movies.Core.MovieKeywords.Repositories;

public interface IMovieKeywordRepository : ICreateAsync<Guid, MovieKeywordDto>, IDeleteAsync<Guid, MovieKeywordDto>, IDeleteRangeById<bool, Guid>
{
    
}
