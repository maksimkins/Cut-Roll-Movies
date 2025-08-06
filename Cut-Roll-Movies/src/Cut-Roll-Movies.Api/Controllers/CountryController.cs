namespace Cut_Roll_Movies.Api.Controllers;

using Cut_Roll_Movies.Api.Common.Controllers;
using Cut_Roll_Movies.Core.Countries.Dtos;
using Cut_Roll_Movies.Core.Countries.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ContryPaginationDto? dto)
    {
        try
        {
            var result = await _countryService.GetAllCountriesAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return this.InternalServerError(ex.Message);
        }
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] ContrySearchByNameDto? dto)
    {
        try
        {
            var result = await _countryService.SearchCountryByNameAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return this.InternalServerError(ex.Message);
        }
    }

    [HttpGet("{isoCode}")]
    public async Task<IActionResult> GetByIsoCode([FromRoute] string? isoCode)
    {
        try
        {
            var result = await _countryService.GetCountryByIsoCodeAsync(isoCode);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return this.InternalServerError(ex.Message);
        }
    }
}
