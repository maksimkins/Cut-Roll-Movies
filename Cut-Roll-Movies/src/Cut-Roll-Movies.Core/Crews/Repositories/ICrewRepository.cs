namespace Cut_Roll_Movies.Core.Crews.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;

public interface ICrewRepository : IGetByIdAsync<Crew?, Guid>, IUpdateAsync<CrewUpdateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>,
    ICreateAsync<CrewCreateDto, Guid>, ISearchAsync<IEnumerable<Crew>, CrewSearchDto>
{
    public Task<IEnumerable<Crew>> GetByMovieIdAsync(Guid movieId);
    public Task<IEnumerable<Crew>> GetByPersonIdAsync(Guid personId);
    public Task<PagedResult<Crew>> GetPagedAsync(int page, int pageSize, string? search);
    public Task BulkCreateAsync(IEnumerable<CrewCreateDto> crewList);
    public Task<bool> ExistsAsync(Guid id);
}
