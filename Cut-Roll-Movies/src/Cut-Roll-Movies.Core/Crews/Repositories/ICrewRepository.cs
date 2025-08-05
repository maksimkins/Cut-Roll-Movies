namespace Cut_Roll_Movies.Core.Crews.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;

public interface ICrewRepository : IUpdateAsync<CrewUpdateDto, Guid?>, IDeleteAsync<CrewDeleteDto, Guid?>,
    ICreateAsync<CrewCreateDto, Guid?>, ISearchAsync<CrewSearchDto, PagedResult<Crew>>, IBulkCreateAsync<CrewCreateDto, bool>,
    IBulkDeleteAsync<CrewDeleteDto, bool>, IDeleteRangeById<Guid, bool>
{
    public Task<PagedResult<Crew>> GetByMovieIdAsync(CrewGetByMovieId dto);
    public Task<PagedResult<Crew>> GetByPersonIdAsync(CrewGetByPersonId dto);
    public Task<bool> ExistsAsync(CrewDto dto);
}
