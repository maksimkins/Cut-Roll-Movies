namespace Cut_Roll_Movies.Core.Casts.Dtos;

public class CastUpdateDto
{
    public int? MovieId { get; set; }

    public int? PersonId { get; set; }

    public string? Character { get; set; }

    public int? CastOrder { get; set; }
}
