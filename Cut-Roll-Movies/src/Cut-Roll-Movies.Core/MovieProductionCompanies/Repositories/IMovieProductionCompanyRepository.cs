using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Models;

namespace Cut_Roll_Movies.Core.MovieProductionCompanies.Repositories;

public interface IMovieProductionCompanyRepository : ICreateAsync<int, MovieProductionCompany>, IDeleteAsync<int, MovieProductionCompany>, IDeleteRangeById<bool, int>
{
    
}
