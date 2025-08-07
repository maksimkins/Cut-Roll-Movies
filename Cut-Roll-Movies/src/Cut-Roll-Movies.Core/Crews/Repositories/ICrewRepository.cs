namespace Cut_Roll_Movies.Core.Crews.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Crews.Dtos;

public interface ICrewRepository : IUpdateAsync<CrewUpdateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>,
    ICreateAsync<CrewCreateDto, Guid?>, ISearchAsync<CrewSearchDto, PagedResult<CrewGetDto>>, IBulkCreateAsync<CrewCreateDto, bool>,
    IBulkDeleteAsync<Guid, bool>, IDeleteRangeById<Guid, bool>
{
    public Task<PagedResult<CrewGetDto>> GetByMovieIdAsync(CrewGetByMovieId dto);
    public Task<PagedResult<CrewGetDto>> GetByPersonIdAsync(CrewGetByPersonId dto);
    public Task<bool> ExistsByIdAsync(Guid id);
}
