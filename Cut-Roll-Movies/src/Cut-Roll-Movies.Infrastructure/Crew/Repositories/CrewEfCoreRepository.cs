namespace Cut_Roll_Movies.Infrastructure.Crew.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.Crews.Repositories;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public class CrewEfCoreRepository : ICrewRepository
{
    private readonly MovieDbContext _dbContext;
    public CrewEfCoreRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> BulkCreateAsync(IEnumerable<CrewCreateDto> listToCreate)
    {
        var newCrew = listToCreate.Select(toCreate => new Crew
        {
            MovieId = toCreate.MovieId,
            PersonId = toCreate.PersonId,
            Job = toCreate.Job,
            Department = toCreate.Department,
        });

        await _dbContext.Crew.AddRangeAsync(newCrew);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0;
    }

    public async Task<bool> BulkDeleteAsync(IEnumerable<Guid> idsToDelete)
    {
        foreach (var item in idsToDelete)
        {
            var crew = await _dbContext.Crew.FirstOrDefaultAsync(c =>
                c.Id == item);

            if (crew != null)
            {
                _dbContext.Crew.Remove(crew);
            }
        }

        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Guid?> CreateAsync(CrewCreateDto entity)
    {
        var crew = new Crew
        {
            MovieId = entity.MovieId,
            PersonId = entity.PersonId,
            Job = entity.Job,
            Department = entity.Department
        };

        await _dbContext.Crew.AddAsync(crew);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? crew.Id : null;
    }

    public async Task<Guid?> DeleteByIdAsync(Guid id)
    {
        var crew = await _dbContext.Crew.FirstOrDefaultAsync(c =>
            c.Id == id);

        if (crew != null)
        {
            _dbContext.Crew.Remove(crew);
        }

        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? id : null;
    }


    public async Task<IEnumerable<Crew>> GetByMovieIdAsync(Guid movieId)
    {
        return await _dbContext.Crew.Where(c => c.MovieId == movieId).ToListAsync();
    }

    public async Task<PagedResult<Crew>> GetByMovieIdAsync(CrewGetByMovieId dto)
    {
        var query = _dbContext.Crew.AsQueryable();
        query = query.Where(c => c.PersonId == dto.MovieId);

        if (dto.PageNumber < 1) dto.PageNumber = 1;
        if (dto.PageSize < 1) dto.PageSize = 10;

        var totalCount = await query.CountAsync();

        query = query.
            Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);

        return new PagedResult<Crew>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = dto.PageNumber,
            PageSize = dto.PageSize
        };
    }

    public async Task<PagedResult<Crew>> GetByPersonIdAsync(CrewGetByPersonId dto)
    {
        var query = _dbContext.Crew.AsQueryable();
        query = query.Where(c => c.PersonId == dto.PersonId);


        if (dto.PageNumber < 1) dto.PageNumber = 1;
        if (dto.PageSize < 1) dto.PageSize = 10;

        var totalCount = await query.CountAsync();

        query = query.
            Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);

        return new PagedResult<Crew>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = dto.PageNumber,
            PageSize = dto.PageSize
        };

    }

    public async Task<Guid?> UpdateAsync(CrewUpdateDto entity)
    {
        var crew = await _dbContext.Crew.FirstOrDefaultAsync(c => c.Id == entity.Id);
        if (crew != null)
        {
            crew.Job = entity.Job ?? crew.Job;
            crew.Department = entity.Department ?? crew.Department;

            _dbContext.Crew.Update(crew);
        }

        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? entity.Id : null;
    }

    public async Task<PagedResult<Crew>> SearchAsync(CrewSearchDto dto)
    {
        var query = _dbContext.Crew
            .Include(c => c.Person)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            query = query.Where(c => c.Person.Name.Contains(dto.Name));
        }

        if (!string.IsNullOrWhiteSpace(dto.JobTitle))
        {
            query = query.Where(c => c.Job != null && c.Job.Contains(dto.JobTitle));
        }

        if (!string.IsNullOrWhiteSpace(dto.Department))
        {
            query = query.Where(c => c.Department != null && c.Department.Contains(dto.Department));
        }

        if (dto.PageNumber < 1) dto.PageNumber = 1;
        if (dto.PageSize < 1) dto.PageSize = 10;

        var totalCount = await query.CountAsync();

        query = query.
            Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);

        return new PagedResult<Crew>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = dto.PageNumber,
            PageSize = dto.PageSize
        };
    }

    public async Task<bool> DeleteRangeById(Guid movieId)
    {
        var toDeletes = _dbContext.Crew.Where(g => g.MovieId == movieId);
        _dbContext.Crew.RemoveRange(toDeletes);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0;
    }
    
    public async Task<bool> ExistsByIdAsync(Guid id)
    {
        return await _dbContext.Crew.AnyAsync(c => c.Id == id);
    }
}
