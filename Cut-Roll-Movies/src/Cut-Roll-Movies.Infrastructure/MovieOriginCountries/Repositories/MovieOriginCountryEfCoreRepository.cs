namespace Cut_Roll_Movies.Infrastructure.MovieOriginCountries.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Dtos;
using Cut_Roll_Movies.Core.MovieOriginCountries.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Repository;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public class MovieOriginCountryEfCoreRepository : IMovieOriginCountryRepository
{
    private readonly MovieDbContext _dbContext;
    public MovieOriginCountryEfCoreRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> BulkCreateAsync(IEnumerable<MovieOriginCountryDto> listToCreate)
    {
        var newList = listToCreate.Select(toCreate => new MovieOriginCountry
        {
            MovieId = toCreate.MovieId,
            CountryCode = toCreate.CountryCode,
        });
        
        await _dbContext.MovieOriginCountries.AddRangeAsync(newList);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0;
    }

    public async Task<bool> BulkDeleteAsync(IEnumerable<MovieOriginCountryDto> listToDelete)
    {
        foreach (var item in listToDelete)
        {
            var movieOriginCountry = await _dbContext.MovieOriginCountries.FirstOrDefaultAsync(c =>
                c.MovieId == item.MovieId && c.CountryCode == item.CountryCode);

            if (movieOriginCountry != null)
            {
                _dbContext.MovieOriginCountries.Remove(movieOriginCountry);
            }
        }

        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Guid?> CreateAsync(MovieOriginCountryDto entity)
    {
        var movieOriginCountry = new MovieOriginCountry
        {
            MovieId = entity.MovieId,
            CountryCode = entity.CountryCode,
        };

        await _dbContext.MovieOriginCountries.AddAsync(movieOriginCountry);
        var res = await _dbContext.SaveChangesAsync();

        return res > 0 ? entity.MovieId : null;
    }

    public async Task<Guid?> DeleteAsync(MovieOriginCountryDto dto)
    {
        var toDelete = await _dbContext.MovieOriginCountries.FirstOrDefaultAsync(g => g.MovieId == dto.MovieId && g.CountryCode == dto.CountryCode);
        if (toDelete != null)
            _dbContext.MovieOriginCountries.Remove(toDelete);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0 ? dto.MovieId : null;
    }

    public async Task<bool> DeleteRangeById(Guid movieId)
    {
        var toDeletes = _dbContext.MovieOriginCountries.Where(i => i.MovieId == movieId);
        _dbContext.RemoveRange(toDeletes);

        var res = await _dbContext.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> ExistsAsync(MovieOriginCountryDto dto)
    {
        return await _dbContext.MovieOriginCountries.AnyAsync(g => g.MovieId == dto.MovieId && g.CountryCode == dto.CountryCode);
    }

    public async Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid movieId)
    {
        return await _dbContext.MovieOriginCountries.Where(g => g.MovieId == movieId).
            Include(g => g.Country).Select(g => g.Country).ToListAsync();
    }

    public async Task<PagedResult<Movie>> GetMoviesByOriginCountryIdAsync(MovieSearchByCountryDto movieSearchByCountryDto)
    {
        var query = _dbContext.Movies
            .Include(m => m.Keywords)
            .ThenInclude(mg => mg.Keyword)
            .AsQueryable();

        if (string.IsNullOrEmpty(movieSearchByCountryDto.Iso3166_1))
        {
            query = query.Where(m => m.OriginCountries.Any(mg => mg.CountryCode == movieSearchByCountryDto.Iso3166_1));
        }

        else if (!string.IsNullOrWhiteSpace(movieSearchByCountryDto.Name))
        {
            query = query.Where(m => m.OriginCountries.Any(k => k.Country.Name.Contains(movieSearchByCountryDto.Name)));
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
