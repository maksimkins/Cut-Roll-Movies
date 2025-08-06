namespace Cut_Roll_Movies.Api.Controllers;

using Cut_Roll_Movies.Api.Common.Controllers;
using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CastController : ControllerBase
{
    private readonly ICastService _castService;

    public CastController(ICastService castService)
    {
        _castService = castService;
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CastCreateDto dto)
    {
        try
        {
            var result = await _castService.CreateCastAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] CastUpdateDto dto)
    {
        try
        {
            var result = await _castService.UpdateCastAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] CastDeleteDto dto)
    {
        try
        {
            var result = await _castService.DeleteCastAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] CastSearchDto request)
    {
        try
        {
            var result = await _castService.SearchCastAsync(request);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpGet("by-movie/{movieId:guid}")]
    public async Task<IActionResult> GetByMovieId(Guid movieId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var dto = new CastGetByMovieIdDto
            {
                MovieId = movieId,
                PageNumber = page,
                PageSize = pageSize
            };

            var result = await _castService.GetCastByMovieIdAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [HttpGet("by-person/{personId:guid}")]
    public async Task<IActionResult> GetByPersonId(Guid personId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var dto = new CastGetByPersonIdDto
            {
                PersonId = personId,
                PageNumber = page,
                PageSize = pageSize
            };

            var result = await _castService.GetCastByPersonIdAsync(dto);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPost("bulk-create")]
    public async Task<IActionResult> BulkCreate([FromBody] IEnumerable<CastCreateDto> toCreate)
    {
        try
        {
            var result = await _castService.BulkCreateCasteAsync(toCreate);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpPost("bulk-delete")]
    public async Task<IActionResult> BulkDelete([FromBody] IEnumerable<CastDeleteDto> toDelete)
    {
        try
        {
            var result = await _castService.BulkDeleteCastAsync(toDelete);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }

    [Authorize(Roles = "Admin,Publisher")]
    [HttpDelete("delete-by-movie/{movieId:guid}")]
    public async Task<IActionResult> DeleteByMovieId(Guid movieId)
    {
        try
        {
            var result = await _castService.DeleteCastRangeByMovieIdAsync(movieId);
            return Ok(result);
        }
        catch (ArgumentNullException ex) { return BadRequest(ex.Message); }
        catch (ArgumentException ex) { return NotFound(ex.Message); }
        catch (InvalidOperationException ex) { return Conflict(ex.Message); }
        catch (Exception ex) { return this.InternalServerError(ex.Message); }
    }
}

