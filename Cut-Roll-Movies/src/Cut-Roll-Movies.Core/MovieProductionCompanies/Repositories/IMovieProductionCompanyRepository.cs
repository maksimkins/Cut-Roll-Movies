using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Dtos;

namespace Cut_Roll_Movies.Core.MovieProductionCompanies.Repositories;

public interface IMovieProductionCompanyRepository : ICreateAsync<int, MovieProductionCompanyDto>, IDeleteAsync<int, MovieProductionCompanyDto>, IDeleteRangeById<bool, int>
{
    
}
