using Cut_Roll_Movies.Core.Genres.Models;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieGenres.Models;

public class MovieGenre
{
    public int MovieId { get; set; }
    
    public int GenreId { get; set; }

    public required Movie Movie { get; set; }

    public required Genre Genre { get; set; }
}
