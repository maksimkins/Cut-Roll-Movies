using Cut_Roll_Movies.Core.MovieGenres.Models;

namespace Cut_Roll_Movies.Core.Genres.Models;

public class Genre
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; } = [];
}
