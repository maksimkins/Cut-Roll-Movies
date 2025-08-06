using System.Text.Json.Serialization;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Crews.Models;

namespace Cut_Roll_Movies.Core.People.Models;

public class Person
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? ProfilePath { get; set; }
    [JsonIgnore]

    public ICollection<Cast> CastRoles { get; set; } = [];
    [JsonIgnore]

    public ICollection<Crew> CrewRoles { get; set; } = [];
}
