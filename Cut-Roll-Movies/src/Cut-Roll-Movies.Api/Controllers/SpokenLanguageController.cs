namespace Cut_Roll_Movies.Api.Controllers;

using Cut_Roll_Movies.Api.Common.Controllers;
using Cut_Roll_Movies.Core.SpokenLanguages.Dtos;
using Cut_Roll_Movies.Core.SpokenLanguages.Service;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SpokenLanguageController : ControllerBase
{
    private readonly ISpokenLanguageService _spokenLanguageService;

    public SpokenLanguageController(ISpokenLanguageService spokenLanguageService)
    {
        _spokenLanguageService = spokenLanguageService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] SpokenLanguagePaginationDto? dto)
    {
        try
        {
            var result = await _spokenLanguageService.GetAllSpokenLanguageAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] SpokenLanguageSearchByNameDto? dto)
    {
        try
        {
            var result = await _spokenLanguageService.SearchSpokenLanguageByNameAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpGet("{isoCode}")]
    public async Task<IActionResult> GetByIsoCode([FromRoute] string? isoCode)
    {
        try
        {
            var result = await _spokenLanguageService.GetSpokenLanguageByIsoCodeAsync(isoCode);
            return result is not null ? Ok(result) : NotFound("Spoken language not found.");
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }
}