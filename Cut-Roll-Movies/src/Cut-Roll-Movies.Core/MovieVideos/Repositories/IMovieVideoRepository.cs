namespace Cut_Roll_Movies.Core.MovieVideos.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieVideos.Dtos;
using Cut_Roll_Movies.Core.MovieVideos.Models;

public interface IMovieVideoRepository : ICreateAsync<Guid, MovieVideoCreateDto>, IDeleteAsync<Guid, Guid>,
IDeleteRangeById<bool, Guid>, IUpdateAsync<MovieVideoUpdateDto, Guid>
{
    Task<IEnumerable<MovieVideo>> GetVideosByMovieIdAsync(Guid movieId);
    Task<IEnumerable<MovieVideo>> GetVideosByTypeAsync(Guid movieId, string type);
}
