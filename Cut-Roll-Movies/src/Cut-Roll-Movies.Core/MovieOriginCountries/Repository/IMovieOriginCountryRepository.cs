using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieOriginCountries.Models;

namespace Cut_Roll_Movies.Core.MovieOriginCountries.Repository;

public interface IMovieOriginCountryRepository : ICreateAsync<int, MovieOriginCountry>, IDeleteAsync<int, MovieOriginCountry>, IDeleteRangeById<bool, int>
{
    
}
