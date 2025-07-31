namespace Cut_Roll_Movies.Core.Casts.Dtos;

public class CastUpdateDto
{
    public Guid MovieId { get; set; }

    public Guid PersonId { get; set; }

    public string? Character { get; set; }

    public int? CastOrder { get; set; }
}
