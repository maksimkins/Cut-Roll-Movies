using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCountries.Models;

namespace Cut_Roll_Movies.Core.MovieProductionCountries.Repostiroes;

public interface IMovieProductionCountryRepository : ICreateAsync<int, MovieProductionCountry>, IDeleteAsync<int, MovieProductionCountry>, IDeleteRangeById<bool, int>
{
    
}
