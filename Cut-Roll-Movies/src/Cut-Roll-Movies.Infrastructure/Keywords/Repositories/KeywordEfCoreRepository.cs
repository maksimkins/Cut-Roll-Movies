namespace Cut_Roll_Movies.Infrastructure.Keywords.Repositories;

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

    public async Task<IEnumerable<Keyword>> GetAllAsync()
    {
        return await _dbContext.Keywords.ToListAsync();
    }

    public async Task<Keyword?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Keywords.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Keyword?> GetByNameAsync(string name)
    {
        return await _dbContext.Keywords.FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task<IEnumerable<Keyword>> SearchAsync(KeywordSearchDto request)
    {
       return await _dbContext.Keywords.Where(g => g.Name.Contains(request.Name)).ToListAsync();
    }
}
