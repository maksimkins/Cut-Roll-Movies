using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.People.Models;

namespace Cut_Roll_Movies.Core.Crews.Models;

public class Crew
{
    public Guid Id { get; set; }

    public Guid MovieId { get; set; }

    public Guid PersonId { get; set; }

    public string? Job { get; set; }

    public string? Department { get; set; }

    public required Movie Movie { get; set; }
    
    public required Person Person { get; set; }
}
