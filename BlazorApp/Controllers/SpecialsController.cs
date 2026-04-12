using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Dados;
using BlazorApp.Model;



namespace BlazorApp.Controllers;


[Route("Specials")]
[ApiController]
public class SpecialsController : Controller
{
    private readonly PizzaStoreContext _db;
    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<List<ModeloPizza>>> Get()
    {
        return (await _db.Pizzas.ToListAsync()).OrderByDescending(s => s.PrecoBase).ToList();
    }
}

