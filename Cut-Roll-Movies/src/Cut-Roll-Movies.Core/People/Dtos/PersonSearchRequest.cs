using System.Dynamic;
using Cut_Roll_Movies.Core.People.Enums;

namespace Cut_Roll_Movies.Core.People.Dtos;

public class PersonSearchRequest
{
    public required string Name { get; set; }
    public PersonSearch? role { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
