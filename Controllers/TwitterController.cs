
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using onpmysql.Models;
using onpmysql.Repositories;


[Route("api/[controller]")]
[ApiController]
public class TwitterController : Controller
{
    private readonly ITwitterRepository _repository;

    public TwitterController(ITwitterRepository repository)
    {
        _repository = repository;
    }


[Authorize(Roles = AppRoles.Administrator )]
    [HttpGet(Name ="fetchallTwitterRecords")]
    public async Task<IActionResult> Details()
    {

        var records = await _repository.GetAllAsync();
        if (records == null) return NotFound();
        else
            return View(records);

    }


    // public async Task<IActionResult> DetailbyId(long id)
    // {
    // var corona = await _repository.GetByIdAsync(id);
    // if (corona == null)
    // {
    // return NotFound();
    // }
    // return    Ok(corona);
    // }


    [Authorize(Roles = $"{AppRoles.User}, {AppRoles.VipUser}, {AppRoles.Administrator}")]

    [HttpGet("{id}")]
    public async Task<ActionResult<Twitter>> DetailbyId(long id)
    {
        var record = await _repository.GetByIdAsync(id); //FindOne or FindASync
        if (record == null) return NotFound();
        return View(record);
    }


    [Authorize(Roles =   $"{AppRoles.User}, {AppRoles.Administrator}")]

    [HttpGet("country/{country}")]
    public async Task<ActionResult<IEnumerable<Twitter>>> GetByCountry([FromRoute] string country)
    {
        return Ok(await _repository.GetByCountryAsync(country));
    }

    [HttpPost]
    public async Task<ActionResult<Twitter>> Create([FromBody] Twitter Twitter)
    {
        await _repository.AddAsync(Twitter);
        return CreatedAtAction(nameof(DetailbyId), new { id = Twitter.C0 }, Twitter);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] Twitter Twitter)
    {
        if (id != Twitter.C0) return BadRequest();
        await _repository.UpdateAsync(Twitter);
        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
