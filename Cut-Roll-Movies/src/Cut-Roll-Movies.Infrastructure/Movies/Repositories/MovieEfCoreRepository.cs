namespace Cut_Roll_Movies.Infrastructure.Movies.Repositories;

using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.MovieImages.Enums;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.Movies.Repositories;
using Cut_Roll_Movies.Core.People.Models;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public class MovieEfCoreRepository : IMovieRepository
{
    private readonly MovieDbContext _context;

    public MovieEfCoreRepository(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<MovieSimplifiedDto>> SearchAsync(MovieSearchRequest request)
    {
        var query = _context.Movies.AsQueryable();

        query = ApplyFilters(query, request);

        var totalCount = await query.CountAsync();

        query = ApplySorting(query, request);

        var movies = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
            .Include(m => m.Cast)
                .ThenInclude(c => c.Person)
            .Include(m => m.Crew)
                .ThenInclude(c => c.Person)
            .Include(m => m.Keywords)
                .ThenInclude(k => k.Keyword)
            .Include(m => m.ProductionCountries)
                .ThenInclude(pc => pc.Country)
            .Include(m => m.SpokenLanguages)
                .ThenInclude(sl => sl.Language)
            .ToListAsync();

        var result = await query.ToListAsync();

        return new PagedResult<MovieSimplifiedDto>()
        {
            Data = result.Select(m => new MovieSimplifiedDto
            {
                MovieId = m.Id,
                Title = m.Title,
                Poster = m.Images?.FirstOrDefault(i => i.Type == ImageTypes.poster.ToString()),
            }).ToList(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }

    private IQueryable<Movie> ApplyFilters(IQueryable<Movie> query, MovieSearchRequest request)
    {
        if (!string.IsNullOrEmpty(request.Title))
            query = query.Where(m => m.Title.Contains(request.Title));

        if (!string.IsNullOrEmpty(request.Genre))
            query = query.Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.Contains(request.Genre)));

        if (!string.IsNullOrEmpty(request.Actor))
            query = query.Where(m => m.Cast.Any(c => c.Person.Name.Contains(request.Actor)));

        if (!string.IsNullOrEmpty(request.Director))
            query = query.Where(m => m.Crew.Any(c => c.Job == "Director" && c.Person.Name.Contains(request.Director)));

        if (!string.IsNullOrEmpty(request.Keyword))
            query = query.Where(m => m.Keywords.Any(k => k.Keyword.Name.Contains(request.Keyword)));

        if (request.Year.HasValue)
            query = query.Where(m => m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year == request.Year.Value);

        if (request.MinRating.HasValue)
            query = query.Where(m => m.VoteAverage >= request.MinRating.Value);

        if (request.MaxRating.HasValue)
            query = query.Where(m => m.VoteAverage <= request.MaxRating.Value);

        if (!string.IsNullOrEmpty(request.Country))
            query = query.Where(m => m.ProductionCountries.Any(pc => pc.Country.Name.Contains(request.Country)));

        if (!string.IsNullOrEmpty(request.Language))
            query = query.Where(m => m.SpokenLanguages.Any(sl => sl.Language.EnglishName.Contains(request.Language)));

        return query;
    }

    private IQueryable<Movie> ApplySorting(IQueryable<Movie> query, MovieSearchRequest request)
    {
        return request.SortBy?.ToLower() switch
        {
            "title" => request.SortDescending ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title),
            "rating" => request.SortDescending ? query.OrderByDescending(m => m.VoteAverage) : query.OrderBy(m => m.VoteAverage),
            "releasedate" => request.SortDescending ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate),
            "revenue" => request.SortDescending ? query.OrderByDescending(m => m.Revenue) : query.OrderBy(m => m.Revenue),
            _ => query.OrderBy(m => m.Title)
        };
    }

    public async Task<Movie?> GetByIdAsync(Guid id)
    {
        return await _context.Movies
            .Include(m => m.MovieGenres)
            .Include(m => m.Cast)
            .Include(m => m.Crew)
            .Include(m => m.ProductionCompanies)
            .Include(m => m.ProductionCountries)
            .Include(m => m.SpokenLanguages)
            .Include(m => m.Videos)
            .Include(m => m.Keywords)
            .Include(m => m.OriginCountries)
            .Include(m => m.Images)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<int> CountAsync()
    {
        return await _context.Movies.CountAsync();
    }

    public async Task<Guid?> CreateAsync(MovieCreateDto entity)
    {
        var movie = new Movie()
        {
            Title = entity.Title,
            Overview = entity.Overview,
            Rating = entity.Rating,
            ImdbId = entity.ImdbId,
            Homepage = entity.Homepage,
            Revenue = entity.Revenue,
            Budget = entity.Budget,
            VoteAverage = entity.VoteAverage,
            Runtime = entity.Runtime,
            ReleaseDate = entity.ReleaseDate,
            Tagline = entity.Tagline,

        };

        _context.Movies.Add(movie);

        await _context.SaveChangesAsync();
        return movie.Id;
    }

    public async Task<Guid?> DeleteByIdAsync(Guid id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
            return null;

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return id;
    }

    public async Task<Guid?> UpdateAsync(MovieUpdateDto entity)
    {
        var existingMovie = await _context.Movies.FindAsync(entity.Id);

        if (existingMovie == null)
            return null;

        if (entity.Title != null)
            existingMovie.Title = entity.Title;

        if (entity.Tagline != null)
            existingMovie.Tagline = entity.Tagline;

        if (entity.Overview != null)
            existingMovie.Overview = entity.Overview;

        if (entity.ReleaseDate.HasValue)
            existingMovie.ReleaseDate = entity.ReleaseDate;

        if (entity.Runtime.HasValue)
            existingMovie.Runtime = entity.Runtime;

        if (entity.Budget.HasValue)
            existingMovie.Budget = entity.Budget;

        if (entity.Revenue.HasValue)
            existingMovie.Revenue = entity.Revenue;

        if (entity.Homepage != null)
            existingMovie.Homepage = entity.Homepage;

        if (entity.ImdbId != null)
            existingMovie.ImdbId = entity.ImdbId;

        await _context.SaveChangesAsync();
        return entity.Id;
    }

}
