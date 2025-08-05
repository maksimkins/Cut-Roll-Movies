namespace Cut_Roll_Movies.Infrastructure.Crew.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.Crews.Repositories;
using Cut_Roll_Movies.Core.Crews.Services;

public class CrewService : ICrewService
{
    private readonly ICrewRepository _crewRepository;
    public CrewService(ICrewRepository crewRepository)
    {
        _crewRepository = crewRepository ?? throw new Exception($"{nameof(_crewRepository)}");
    }

    public async Task<bool> BulkCreateCrewAsync(IEnumerable<CrewCreateDto>? crewList)
    {
        if (crewList == null || !crewList.Any())
            throw new ArgumentException(message: $"there is no instances to create");

        foreach (var c in crewList)
        {
            if (c == null)
                throw new ArgumentNullException("one of the object is null");

            var exists = await _crewRepository.ExistsAsync(new CrewDto
            {
                MovieId = c.MovieId,
                PersonId = c.PersonId,
            });

            if (exists)
                throw new ArgumentException($"crew with MovieId: {c.MovieId} and PersonId: {c.PersonId} already exists");
            
        }

        return await _crewRepository.BulkCreateAsync(crewList);
    }

    public async Task<bool> BulkDeleteCrewAsync(IEnumerable<CrewDeleteDto>? crewList)
    {
        if (crewList == null || !crewList.Any())
            throw new ArgumentException(message: $"there is no instances to delete");
        
                foreach (var c in crewList)
        {
            if (c == null)
                throw new ArgumentNullException("one of the object is null");
            if (c.MovieId == Guid.Empty)
                throw new ArgumentNullException($"missing {c.MovieId}");
            if (c.PersonId == Guid.Empty)
                throw new ArgumentNullException($"missing {c.PersonId}");

            var exists = await _crewRepository.ExistsAsync(new CrewDto
            {
                MovieId = c.MovieId,
                PersonId = c.PersonId,
            });

            if (!exists)
                throw new ArgumentException($"cannot find crew with MovieId: {c.MovieId} and PersonId: {c.PersonId}");
            
        }

        return await _crewRepository.BulkDeleteAsync(crewList);
    }

    public async Task<Guid> CreateCrewAsync(CrewCreateDto? dto)
    {
        if (dto == null)
            throw new ArgumentException(message: "nothing to create");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.MovieId)}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.PersonId)}");
        if (dto.Job == null)
            throw new ArgumentNullException($"missing {nameof(dto.Job)}");
        if (dto.Department == null)
            throw new ArgumentNullException($"missing {nameof(dto.Department)}");

        if (await _crewRepository.ExistsAsync(new CrewDto
        {
            MovieId = dto.MovieId,
            PersonId = dto.PersonId,
        }))
            throw new ArgumentException($"crew with MovieId: {dto.MovieId} and PersonId: {dto.PersonId} already exists");
            
        return await _crewRepository.CreateAsync(dto) ??
            throw new Exception(message: "could not create crew");
    }

    public async Task<Guid> DeleteCrewAsync(CrewDeleteDto? dto)
    {
        if (dto == null)
            throw new ArgumentException(message: "nothing to delete");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.MovieId)}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.PersonId)}");
        
        if (!await _crewRepository.ExistsAsync(new CrewDto
        {
            MovieId = dto.MovieId,
            PersonId = dto.PersonId,
        }))
            throw new ArgumentException($"cannot find crew with MovieId: {dto.MovieId} and PersonId: {dto.PersonId}");

        return await _crewRepository.DeleteAsync(dto) ??
            throw new Exception(message: "could not delete crew");
    }

    public async Task<PagedResult<Crew>> GetCrewByPersonIdAsync(CrewGetByPersonId? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.PersonId)}");
        
        return await _crewRepository.GetByPersonIdAsync(dto);
    }

    public async Task<PagedResult<Crew>> GetCrewByMovieIdAsync(CrewGetByMovieId? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.MovieId)}");

        return await _crewRepository.GetByMovieIdAsync(dto);
    }

    public async Task<PagedResult<Crew>> SearchCrewAsync(CrewSearchDto? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.JobTitle == null && dto.Name == null && dto.Department == null)
            throw new ArgumentException($"no arguments to search by ({nameof(dto.JobTitle)}, {dto.Name}, {dto.Department})");

        return await _crewRepository.SearchAsync(dto);
    }

    public async Task<Guid> UpdateCrewAsync(CrewUpdateDto? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentException($"missing {dto.MovieId}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentException($"missing {dto.PersonId}");
        if (dto.Job == null && dto.Department == null)
            throw new ArgumentException($"no arguments to update ({nameof(dto.Job)}, {dto.Department})");

        if (!await _crewRepository.ExistsAsync(new CrewDto
        {
            MovieId = dto.MovieId,
            PersonId = dto.PersonId,
        }))
            throw new ArgumentException($"cannot find crew with MovieId: {dto.MovieId} and PersonId: {dto.PersonId}");

        return await _crewRepository.UpdateAsync(dto) ??
            throw new Exception(message: "could not update crew");
    }

    public async Task<bool> DeleteCrewRangeByMovieIdAsync(Guid? movieId)
    {
        if (movieId == null || movieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(movieId)}");
            
        return await _crewRepository.DeleteRangeById(movieId.Value);
    }
}
