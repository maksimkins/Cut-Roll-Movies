namespace Cut_Roll_Movies.Core.Crews.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;

public interface ICrewRepository : IGetByIdAsync<Guid, Crew?>, IUpdateAsync<CrewUpdateDto, Guid?>, IDeleteAsync<CrewDeleteDto, Guid?>,
    ICreateAsync<CrewCreateDto, Guid?>, ISearchAsync<CrewSearchDto, IEnumerable<Crew>>, IBulkCreateAsync<CrewCreateDto, bool>,
    IBulkDeleteAsync<CrewDeleteDto, bool>
{
    public Task<IEnumerable<Crew>> GetByMovieIdAsync(Guid movieId);
    public Task<IEnumerable<Crew>> GetByPersonIdAsync(Guid personId);
    public Task<bool> ExistsAsync(Guid id);
}
