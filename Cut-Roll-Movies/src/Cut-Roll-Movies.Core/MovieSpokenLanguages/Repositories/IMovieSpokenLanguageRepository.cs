using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Dtos;

namespace Cut_Roll_Movies.Core.MovieSpokenLanguages.Repositories;

public interface IMovieSpokenLanguageRepository : ICreateAsync<int, MovieSpokenLanguageDto>, IDeleteAsync<int, MovieSpokenLanguageDto>, IDeleteRangeById<bool, int>
{
    
}
