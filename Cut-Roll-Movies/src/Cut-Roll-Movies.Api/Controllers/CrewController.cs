namespace Cut_Roll_Movies.Api.Controllers;

using Cut_Roll_Movies.Api.Common.Controllers;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.Crews.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CrewController : ControllerBase
{
    private readonly ICrewService _crewService;

    public CrewController(ICrewService crewService)
    {
        _crewService = crewService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] CrewSearchDto? request)
    {
        try
        {
            var result = await _crewService.SearchCrewAsync(request);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpGet("by-movie/{movieId:guid}")]
    public async Task<IActionResult> GetByMovieId([FromRoute] Guid movieId)
    {
        try
        {
            var dto = new CrewGetByMovieId { MovieId = movieId };
            var result = await _crewService.GetCrewByMovieIdAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpGet("by-person/{personId:guid}")]
    public async Task<IActionResult> GetByPersonId([FromRoute] Guid personId)
    {
        try
        {
            var dto = new CrewGetByPersonId { PersonId = personId };
            var result = await _crewService.GetCrewByPersonIdAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrewCreateDto? dto)
    {
        try
        {
            var id = await _crewService.CreateCrewAsync(dto);
            return Ok(id);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPost("bulk")]
    public async Task<IActionResult> BulkCreate([FromBody] IEnumerable<CrewCreateDto>? crewList)
    {
        try
        {
            var success = await _crewService.BulkCreateCrewAsync(crewList);
            return Ok(success);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CrewUpdateDto? dto)
    {
        try
        {
            var id = await _crewService.UpdateCrewAsync(dto);
            return Ok(id);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] CrewDeleteDto? dto)
    {
        try
        {
            var id = await _crewService.DeleteCrewAsync(dto);
            return Ok(id);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpDelete("bulk")]
    public async Task<IActionResult> BulkDelete([FromBody] IEnumerable<CrewDeleteDto>? crewList)
    {
        try
        {
            var result = await _crewService.BulkDeleteCrewAsync(crewList);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpDelete("delete-by-movie/{movieId:guid}")]
    public async Task<IActionResult> DeleteByMovieId([FromRoute] Guid movieId)
    {
        try
        {
            var result = await _crewService.DeleteCrewRangeByMovieIdAsync(movieId);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }
}
