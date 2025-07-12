using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;

namespace Cut_Roll_Movies.Core.Crews.Repositories;

public interface ICrewRepository : IGetByIdAsync<Crew?, int>, IUpdateAsync<CrewUpdateDto, int?>, IDeleteByIdAsync<int, int?>, ICreateAsync<CrewCreateDto, int>
{
    
}
