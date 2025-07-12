using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;

namespace Cut_Roll_Movies.Core.MovieSpokenLanguages.Repositories;

public interface IMovieSpokenLanguageRepository : ICreateAsync<int, MovieSpokenLanguage>, IDeleteAsync<int, MovieSpokenLanguage>, IDeleteRangeById<bool, int>
{
    
}
