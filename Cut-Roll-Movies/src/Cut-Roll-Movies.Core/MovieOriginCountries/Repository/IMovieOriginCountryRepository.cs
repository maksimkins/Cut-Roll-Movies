using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieOriginCountries.Dtos;

namespace Cut_Roll_Movies.Core.MovieOriginCountries.Repository;

public interface IMovieOriginCountryRepository : ICreateAsync<Guid, MovieOriginCountryDto>, IDeleteAsync<Guid, MovieOriginCountryDto>, IDeleteRangeById<bool, Guid>
{
    
}
