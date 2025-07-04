using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Crews.Models;

namespace Cut_Roll_Movies.Core.People.Models;

public class Person
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? ProfilePath { get; set; }

    public ICollection<Cast> CastRoles { get; set; } = [];

    public ICollection<Crew> CrewRoles { get; set; } = [];
}
