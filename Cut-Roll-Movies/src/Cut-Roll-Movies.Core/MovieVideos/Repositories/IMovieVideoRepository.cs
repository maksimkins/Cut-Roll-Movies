namespace Cut_Roll_Movies.Core.MovieVideos.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieVideos.Dtos;
using Cut_Roll_Movies.Core.MovieVideos.Models;

public interface IMovieVideoRepository : ICreateAsync<MovieVideoCreateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>,
IDeleteRangeById<Guid, bool>, IUpdateAsync<MovieVideoUpdateDto, Guid?>
{
    Task<IEnumerable<MovieVideo>> GetVideosByMovieIdAsync(Guid movieId);
    Task<IEnumerable<MovieVideo>> GetVideosByTypeAsync(MovieVideoSearchDto movieVideoSearchDto);
}
