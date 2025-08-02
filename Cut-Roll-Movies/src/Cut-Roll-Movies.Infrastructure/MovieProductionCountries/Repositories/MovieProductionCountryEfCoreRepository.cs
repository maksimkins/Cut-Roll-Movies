namespace Cut_Roll_Movies.Infrastructure.MovieProductionCountries.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;
using Cut_Roll_Movies.Core.MovieProductionCountries.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Repositories;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public class MovieProductionCountryEfCoreRepository : IMovieProductionCountryRepository
{
    private readonly MovieDbContext _dbContext;
    public MovieProductionCountryEfCoreRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> BulkCreateAsync(IEnumerable<MovieProductionCountryDto> listToCreate)
    {
        var newList = listToCreate.Select(toCreate => new MovieProductionCountry
        {
            MovieId = toCreate.MovieId,
            CountryCode = toCreate.CountryCode,
        });
        
        await _dbContext.MovieProductionCountries.AddRangeAsync(newList);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0;
    }

    public async Task<bool> BulkDeleteAsync(IEnumerable<MovieProductionCountryDto> listToDelete)
    {
        foreach (var item in listToDelete)
        {
            var movieProductionCountry = await _dbContext.MovieProductionCountries.FirstOrDefaultAsync(c =>
                c.MovieId == item.MovieId && c.CountryCode == item.CountryCode);

            if (movieProductionCountry != null)
            {
                _dbContext.MovieProductionCountries.Remove(movieProductionCountry);
            }
        }

        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Guid?> CreateAsync(MovieProductionCountryDto entity)
    {
        var movieProductionCountry = new MovieProductionCountry
        {
            MovieId = entity.MovieId,
            CountryCode = entity.CountryCode,
        };

        await _dbContext.MovieProductionCountries.AddAsync(movieProductionCountry);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? entity.MovieId : null;
    }

    public async Task<Guid?> DeleteAsync(MovieProductionCountryDto dto)
    {
        var toDelete = await _dbContext.MovieProductionCountries.FirstOrDefaultAsync(g => g.MovieId == dto.MovieId && g.CountryCode == dto.CountryCode);
        if (toDelete != null)
            _dbContext.MovieProductionCountries.Remove(toDelete);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0 ? dto.MovieId : null;
    }

    public async Task<bool> DeleteRangeById(Guid movieId)
    {
        var toDeletes = _dbContext.MovieProductionCountries.Where(i => i.MovieId == movieId);
        _dbContext.RemoveRange(toDeletes);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> ExistsAsync(MovieProductionCountryDto dto)
    {
        return await _dbContext.MovieProductionCountries.AnyAsync(g => g.MovieId == dto.MovieId && g.CountryCode == dto.CountryCode);
    }

    public async Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid movieId)
    {
        return await _dbContext.MovieProductionCountries.Where(g => g.MovieId == movieId).
            Include(g => g.Country).Select(g => g.Country).ToListAsync();
    }

    public async Task<PagedResult<Movie>> GetMoviesByCountryIdAsync(MovieSearchByCountryDto movieSearchByCountryDto)
    {
        var query = _dbContext.Movies
            .Include(m => m.Keywords)
            .ThenInclude(mg => mg.Keyword)
            .AsQueryable();

        if (string.IsNullOrEmpty(movieSearchByCountryDto.Iso3166_1))
        {
            query = query.Where(m => m.ProductionCountries.Any(mg => mg.CountryCode == movieSearchByCountryDto.Iso3166_1));
        }

        else if (!string.IsNullOrWhiteSpace(movieSearchByCountryDto.Name))
        {
            query = query.Where(m => m.ProductionCountries.Any(k => k.Country.Name.Contains(movieSearchByCountryDto.Name)));
        }

        if (movieSearchByCountryDto.PageNumber < 1) movieSearchByCountryDto.PageNumber = 1;
        if (movieSearchByCountryDto.PageSize < 1) movieSearchByCountryDto.PageSize = 10;

        var totalCount = await query.CountAsync();

        query = query.
            Skip((movieSearchByCountryDto.PageNumber - 1) * movieSearchByCountryDto.PageSize)
            .Take(movieSearchByCountryDto.PageSize);

        return new PagedResult<Movie>()
        {
            Data = await query.ToListAsync(),
            TotalCount = totalCount,
            Page = movieSearchByCountryDto.PageNumber,
            PageSize = movieSearchByCountryDto.PageSize
        };
    }
}
