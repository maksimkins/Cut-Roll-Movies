namespace Cut_Roll_Movies.Core.Crews.Services;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;

public interface ICrewService
{
    Task<Crew?> GetCrewByIdAsync(Guid? id);
    Task<Guid> UpdateCrewAsync(CrewUpdateDto? dto);
    Task<Guid> DeleteCrewAsync(CrewDeleteDto? dto);
    Task<Guid> CreateCrewAsync(CrewCreateDto? dto);
    Task<PagedResult<Crew>> SearchCrewAsync(CrewSearchDto? request);
    public Task<PagedResult<Crew>> GetCrewByMovieIdAsync(CrewGetByMovieId? dto);
    public Task<bool> BulkCreateCrewAsync(IEnumerable<CrewCreateDto?>? crewList);
    public Task<bool> BulkDeleteCrewAsync(IEnumerable<CrewDeleteDto?>? crewList);
    public Task<PagedResult<Crew>> GetByPersonIdAsync(CrewGetByPersonId? dto);
}



