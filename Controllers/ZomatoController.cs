using Microsoft.AspNetCore.Mvc;
using onpmysql.DbData;
using ZomatoDb.Models;
[Route("zomato/[controller]")]

public class ZomatoController : Controller
{
    private readonly CsvDbContext _context;

    public ZomatoController(CsvDbContext context)
    {
        _context = context;
    }

    [Route("list")]
    public IActionResult zomato()
    {
        var data = _context.ZomatotableEntity.ToList(); // Fetches from MySQL
        return View(data); // Passes to Razor View
    }
}
