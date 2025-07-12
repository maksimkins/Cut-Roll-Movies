using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieVideos.Dtos;

namespace Cut_Roll_Movies.Core.MovieVideos.Repositories;

public interface IMovieVideoRepository : ICreateAsync<int, MovieVideoCreateDto>, IDeleteAsync<int, int>,
IDeleteRangeById<bool, int>, IUpdateAsync<MovieVideoUpdateDto, int>
{
    
}
