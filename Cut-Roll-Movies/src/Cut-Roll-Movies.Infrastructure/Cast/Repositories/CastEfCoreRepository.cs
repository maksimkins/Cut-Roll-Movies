namespace Cut_Roll_Movies.Infrastructure.Cast.Repositories;

using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Casts.Repositories;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public class CastEfCoreRepository : ICastRepository
{
    private readonly MovieDbContext _dbContext;
    public CastEfCoreRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> BulkCreateAsync(IEnumerable<CastCreateDto> listToCreate)
    {
        var newCasts = listToCreate.Select(toCreate => new Cast
        {
            MovieId = toCreate.MovieId,
            PersonId = toCreate.PersonId,
            Character = toCreate.Character,
            CastOrder = toCreate.CastOrder,
        });
        
        await _dbContext.Cast.AddRangeAsync(newCasts);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0;
    }

 public async Task<bool> BulkDeleteAsync(IEnumerable<CastDeleteDto> listToDelete)
    {
        foreach (var item in listToDelete)
        {
            var cast = await _dbContext.Cast.FirstOrDefaultAsync(c =>
                c.MovieId == item.MovieId && c.PersonId == item.PersonId);

            if (cast != null)
            {
                _dbContext.Cast.Remove(cast);
            }
        }

        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Guid?> CreateAsync(CastCreateDto entity)
    {
        var cast = new Cast
        {
            MovieId = entity.MovieId,
            PersonId = entity.PersonId,
            Character = entity.Character,
            CastOrder = entity.CastOrder
        };

        await _dbContext.Cast.AddAsync(cast);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? entity.MovieId : null;
    }

    public async Task<Guid?> DeleteAsync(CastDeleteDto entity)
    {
        var cast = await _dbContext.Cast.FirstOrDefaultAsync(c =>
            c.MovieId == entity.MovieId && c.PersonId == entity.PersonId);

        if (cast != null)
            _dbContext.Remove(cast);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0 ? entity.MovieId : null;
    }

    public async Task<bool> ExistsAsync(CastDto dto)
    {
        return await _dbContext.Cast.AnyAsync(c =>
            c.MovieId == dto.MovieId && c.PersonId == dto.PersonId);
    }


    public async Task<PagedResult<Cast>> GetByMovieIdAsync(CastGetByMovieIdDto dto)
    {
        var query = _dbContext.Cast.AsQueryable();
        query = query.Where(c => c.MovieId == dto.MovieId).Include(c => c.Person);

        var totalCount = await query.CountAsync();

        query = query.
            Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);

        return new PagedResult<Cast>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = dto.PageNumber,
            PageSize = dto.PageSize
        };

    }

    public async Task<PagedResult<Cast>> GetByPersonIdAsync(CastGetByPersonIdDto dto)
    {
        var query = _dbContext.Cast.Include(i => i.Person).AsQueryable();

        query = query.Where(c => c.PersonId == dto.PersonId);

        var totalCount = await query.CountAsync();

        query = query.
            Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);

        return new PagedResult<Cast>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = dto.PageNumber,
            PageSize = dto.PageSize
        };
    }


    public async Task<Guid?> UpdateAsync(CastUpdateDto entity)
    {
        var cast = await _dbContext.Cast.FirstOrDefaultAsync(c => c.MovieId == entity.MovieId && c.PersonId == entity.PersonId);
        if (cast != null)
        {
            cast.Character = entity.Character ?? cast.Character;
            cast.CastOrder = entity.CastOrder ?? cast.CastOrder;

            _dbContext.Cast.Update(cast);
        }   
        
        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? entity.MovieId : null;
    }

    public async Task<PagedResult<Cast>> SearchAsync(CastSearchDto request)
    {
        var query = _dbContext.Cast
            .Include(c => c.Person) 
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(c => c.Person.Name.Contains(request.Name));
        }

        if (!string.IsNullOrWhiteSpace(request.CharacterName))
        {
            query = query.Where(c => c.Character != null && c.Character.Contains(request.CharacterName));
        }

        if (request.PageNumber < 1) request.PageNumber = 1;
        if (request.PageSize < 1) request.PageSize = 10;
        
        var totalCount = await query.CountAsync();

        query = query.
            Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        return new PagedResult<Cast>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = request.PageNumber,
            PageSize = request.PageSize
        };
    }

    public async Task<bool> DeleteRangeById(Guid movieId)
    {
        var toDeletes = _dbContext.Cast.Where(g => g.MovieId == movieId);
        _dbContext.Cast.RemoveRange(toDeletes);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0;
    }
}
