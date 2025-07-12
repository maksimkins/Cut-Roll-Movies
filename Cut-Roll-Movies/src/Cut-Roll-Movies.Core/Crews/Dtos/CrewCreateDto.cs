namespace Cut_Roll_Movies.Core.Crews.Dtos;

public class CrewCreateDto
{
    public int MovieId { get; set; }

    public int PersonId { get; set; }

    public string? Job { get; set; }

    public string? Department { get; set; }

}
