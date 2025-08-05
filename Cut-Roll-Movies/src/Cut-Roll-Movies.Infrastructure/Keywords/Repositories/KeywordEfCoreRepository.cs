namespace Cut_Roll_Movies.Infrastructure.Keywords.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Keywords.Dtos;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.Keywords.Repositories;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public class KeywordEfCoreRepository : IKeywordRepository
{
    private readonly MovieDbContext _dbContext;
    public KeywordEfCoreRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid?> CreateAsync(KeywordCreateDto entity)
    {
        var keyword = new Keyword
        {
            Name = entity.Name,
        };

        await _dbContext.Keywords.AddAsync(keyword);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? keyword.Id : null;
    }

    public async Task<Guid?> DeleteByIdAsync(Guid id)
    {
        var toDelete = await _dbContext.Keywords.FirstOrDefaultAsync(g => g.Id == id);
        if (toDelete != null)
            _dbContext.Keywords.Remove(toDelete);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0 ? id : null;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Keywords.AnyAsync(g => g.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _dbContext.Keywords.AnyAsync(g => g.Name == name);
    }


    public async Task<PagedResult<Keyword>> GetAllAsync(KeywordPaginationDto dto)
    {
        var query = _dbContext.Keywords.AsQueryable();

        if (dto.PageNumber < 1) dto.PageNumber = 1;
        if (dto.PageSize < 1) dto.PageSize = 10;

        var totalCount = await query.CountAsync();

        query = query.
            Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);

        return new PagedResult<Keyword>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = dto.PageNumber,
            PageSize = dto.PageSize
        };
    }
    public async Task<Keyword?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Keywords.FirstOrDefaultAsync(g => g.Id == id);
    }


    public async Task<PagedResult<Keyword>> SearchAsync(KeywordSearchDto request)
    {
        var query = _dbContext.Keywords.AsQueryable();

        query = query.Where(g => g.Name.Contains(request.Name));

        if (request.PageNumber < 1) request.PageNumber = 1;
        if (request.PageSize < 1) request.PageSize = 10;

        var totalCount = await query.CountAsync();

        query = query.
            Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        return new PagedResult<Keyword>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
