namespace Cut_Roll_Movies.Infrastructure.Cast.Services;

using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Casts.Repositories;
using Cut_Roll_Movies.Core.Casts.Services;
using Cut_Roll_Movies.Core.Common.Dtos;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepository;
    public CastService(ICastRepository castRepository)
    {
        _castRepository = castRepository ?? throw new Exception($"{nameof(_castRepository)}");
    }
    public async Task<bool> BulkCreateCasteAsync(IEnumerable<CastCreateDto>? toCreate)
    {
        if (toCreate == null || !toCreate.Any())
            throw new ArgumentException(message: $"there is no instances to create");

        foreach (var c in toCreate)
        {
            if (c == null)
                throw new ArgumentNullException("one of the object is null");
            if (c.MovieId == Guid.Empty)
                throw new ArgumentException($"missing {c.MovieId}");
            if (c.PersonId == Guid.Empty)
                throw new ArgumentException($"missing {c.PersonId}");

            var exists = await _castRepository.ExistsAsync(new CastDto
            {
                MovieId = c.MovieId,
                PersonId = c.PersonId,
            });

            if (exists)
                throw new ArgumentException($"cast with MovieId: {c.MovieId} and PersonId: {c.PersonId} already exists");
            
        }

        return await _castRepository.BulkCreateAsync(toCreate);
    }

    public async Task<bool> BulkDeleteCastAsync(IEnumerable<CastDeleteDto>? toDelete)
    {
        if (toDelete == null || !toDelete.Any())
            throw new ArgumentException(message: $"there is no instances to delete");
        
                foreach (var c in toDelete)
        {
            if (c == null)
                throw new ArgumentNullException("one of the object is null");
            if (c.MovieId == Guid.Empty)
                throw new ArgumentException($"missing {c.MovieId}");
            if (c.PersonId == Guid.Empty)
                throw new ArgumentException($"missing {c.PersonId}");

            var exists = await _castRepository.ExistsAsync(new CastDto
            {
                MovieId = c.MovieId,
                PersonId = c.PersonId,
            });

            if (!exists)
                throw new ArgumentException($"cannot find cast with MovieId: {c.MovieId} and PersonId: {c.PersonId}");
            
        }

        return await _castRepository.BulkDeleteAsync(toDelete);
    }

    public async Task<Guid> CreateCastAsync(CastCreateDto? dto)
    {
        if (dto == null)
            throw new ArgumentException(message: "nothing to create");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.MovieId)}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.PersonId)}");
        if (dto.Character == null)
            throw new ArgumentNullException($"missing {nameof(dto.Character)}");

        if (await _castRepository.ExistsAsync(new CastDto
        {
            MovieId = dto.MovieId,
            PersonId = dto.PersonId,
        }))
            throw new ArgumentException($"cast with MovieId: {dto.MovieId} and PersonId: {dto.PersonId} already exists");
            
        return await _castRepository.CreateAsync(dto) ??
            throw new Exception(message: "could not create cast");
    }

    public async Task<Guid> DeleteCastAsync(CastDeleteDto? dto)
    {
        if (dto == null)
            throw new ArgumentException(message: "nothing to delete");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.MovieId)}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.PersonId)}");
        
        if (!await _castRepository.ExistsAsync(new CastDto
        {
            MovieId = dto.MovieId,
            PersonId = dto.PersonId,
        }))
            throw new ArgumentException($"cannot find cast with MovieId: {dto.MovieId} and PersonId: {dto.PersonId}");

        return await _castRepository.DeleteAsync(dto) ??
            throw new Exception(message: "could not delete cast");
    }

    public async Task<bool> DeleteCastRangeByMovieIdAsync(Guid? movieId)
    {
        if (movieId == null || movieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(movieId)}");
            
        return await _castRepository.DeleteRangeById(movieId.Value);
    }

    public async Task<PagedResult<Cast>> GetCastByMovieIdAsync(CastGetByMovieIdDto? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.MovieId)}");

        return await _castRepository.GetByMovieIdAsync(dto);
    }

    public async Task<PagedResult<Cast>> GetCastByPersonIdAsync(CastGetByPersonIdDto? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentNullException($"missing {nameof(dto.PersonId)}");
        
        return await _castRepository.GetByPersonIdAsync(dto);
    }

    public async Task<PagedResult<Cast>> SearchCastAsync(CastSearchDto? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.CharacterName == null && dto.Name == null)
            throw new ArgumentException($"no arguments to search by ({nameof(dto.CharacterName)}, {dto.Name})");

        return await _castRepository.SearchAsync(dto);
    }

    public async Task<Guid> UpdateCastAsync(CastUpdateDto? dto)
    {
        if (dto == null)
            throw new ArgumentNullException($"missing {nameof(dto)}");
        if (dto.MovieId == Guid.Empty)
            throw new ArgumentException($"missing {dto.MovieId}");
        if (dto.PersonId == Guid.Empty)
            throw new ArgumentException($"missing {dto.PersonId}");
        if (dto.Character == null && dto.CastOrder == null)
            throw new ArgumentException($"no arguments to update ({nameof(dto.Character)}, {dto.CastOrder})");

        if (!await _castRepository.ExistsAsync(new CastDto
        {
            MovieId = dto.MovieId,
            PersonId = dto.PersonId,
        }))
            throw new ArgumentException($"cannot find cast with MovieId: {dto.MovieId} and PersonId: {dto.PersonId}");

        return await _castRepository.UpdateAsync(dto) ??
            throw new Exception(message: "could not update cast");
    }
}
