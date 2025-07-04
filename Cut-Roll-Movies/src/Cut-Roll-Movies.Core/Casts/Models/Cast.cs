using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.People.Models;

namespace Cut_Roll_Movies.Core.Casts.Models;

public class Cast
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int PersonId { get; set; }

    public string? Character { get; set; }

    public int CastOrder { get; set; }

    public required Movie Movie { get; set; }
    
    public required Person Person { get; set; }
}
