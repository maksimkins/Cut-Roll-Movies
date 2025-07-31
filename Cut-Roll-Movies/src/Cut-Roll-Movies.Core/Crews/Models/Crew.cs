#pragma warning disable CS8618

using System.Text.Json.Serialization;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.People.Models;

namespace Cut_Roll_Movies.Core.Crews.Models;

public class Crew
{
    public Guid MovieId { get; set; }
    public Guid PersonId { get; set; }
    public string? Job { get; set; }
    public string? Department { get; set; }
    public Movie Movie { get; set; }
    public Person Person { get; set; }
}
