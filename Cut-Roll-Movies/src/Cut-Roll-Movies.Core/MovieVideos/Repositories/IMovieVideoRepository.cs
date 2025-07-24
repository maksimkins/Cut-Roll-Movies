using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieVideos.Dtos;

namespace Cut_Roll_Movies.Core.MovieVideos.Repositories;

public interface IMovieVideoRepository : ICreateAsync<Guid, MovieVideoCreateDto>, IDeleteAsync<Guid, Guid>,
IDeleteRangeById<bool, Guid>, IUpdateAsync<MovieVideoUpdateDto, Guid>
{
    
}
