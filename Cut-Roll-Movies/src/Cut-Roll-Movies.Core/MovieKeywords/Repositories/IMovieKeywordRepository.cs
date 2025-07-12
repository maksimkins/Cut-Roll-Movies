using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieKeywords.Models;

namespace Cut_Roll_Movies.Core.MovieKeywords.Repositories;

public interface IMovieKeywordRepository : ICreateAsync<int, MovieKeyword>, IDeleteAsync<int, MovieKeyword>, IDeleteRangeById<bool, int>
{
    
}
