using Microsoft.AspNetCore.Mvc;
using Test2.DTO;
using Test2.Services;

namespace Test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _service;

    public BooksController(IBooksService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetPublishingHouses([FromQuery] string? city, [FromQuery] string? country)
    {
        try
        {
            return Ok(await _service.GetPublishingHousesInfo(city, country));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] NewBookForm form)
    {
        try
        {
            await _service.AddBook(form);
            return Created();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}