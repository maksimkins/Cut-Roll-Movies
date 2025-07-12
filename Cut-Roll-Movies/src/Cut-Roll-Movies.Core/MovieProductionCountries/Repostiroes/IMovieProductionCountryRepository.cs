using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;

namespace Cut_Roll_Movies.Core.MovieProductionCountries.Repostiroes;

public interface IMovieProductionCountryRepository : ICreateAsync<int, MovieProductionCountryDto>, IDeleteAsync<int, MovieProductionCountryDto>, IDeleteRangeById<bool, int>
{
    
}
