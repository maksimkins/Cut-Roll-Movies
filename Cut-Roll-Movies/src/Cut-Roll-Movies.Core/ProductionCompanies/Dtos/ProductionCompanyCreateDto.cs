namespace Cut_Roll_Movies.Core.ProductionCompanies.Dtos;

public class ProductionCompanyCreateDto
{
    public required string Name { get; set; }

    public string? CountryCode { get; set; }

    public string? LogoPath { get; set; }
}
