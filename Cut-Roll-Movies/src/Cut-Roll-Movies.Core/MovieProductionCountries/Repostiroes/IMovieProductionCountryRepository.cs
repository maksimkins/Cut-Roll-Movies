using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;

namespace Cut_Roll_Movies.Core.MovieProductionCountries.Repostiroes;

public interface IMovieProductionCountryRepository : ICreateAsync<Guid, MovieProductionCountryDto>, IDeleteAsync<Guid, MovieProductionCountryDto>,
IDeleteRangeById<bool, Guid>
{
    
}
