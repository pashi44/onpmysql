using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onpmysql.DbData;
using Microsoft.Extensions.Logging;
using ZomatoDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Connections;
using StackExchange.Redis;
// [Route("[controller]")]

// [Authorize] //for the whole Controller

[Route("api/[controller]")]
[ApiController]
//  for  json apis not for razor vires
public class ZomatoController : Controller
{
    private readonly CsvDbContext _context;



    private readonly ILogger<ZomatoController> _logger;


    public ZomatoController(CsvDbContext context, ILogger<ZomatoController> logger)
    {
        _context = context;
        _logger = logger;    }
    
    [Authorize(Roles =   $"{AppRoles.User}, {AppRoles.VipUser}, {AppRoles.Administrator}")]
    // [Authorize(Roles = AppRoles.VipUser)]

    [HttpGet("records", Name = "GetallZomatoRecords")]
    public async Task<ActionResult<ZomatoModelOne>> Zomato()
    {
        var data = await _context.ZomatotableEntity.ToListAsync(); // Fetches from MySQL
        return View(data); // Passes to Razor View
    }




    [Authorize(Roles=AppRoles.User)]
    [HttpGet("{id}", Name = "GetById")]
    public async Task<ActionResult<ZomatoModelOne>> Details(long id)
    {

        _logger.LogInformation($"  wueyinght indecx  {id}");

        var record = await _context.ZomatotableEntity.FirstOrDefaultAsync<ZomatoModelOne>(
            obj => obj.RestaurantId == id
            );
        if (record == null) return BadRequest(ModelState);

        return View("Details", record);
    }



} 