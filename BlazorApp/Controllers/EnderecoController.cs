using BlazorApp.Dados;
using BlazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Controllers
{
    [Route("endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly PizzaStoreContext _db;
        public EnderecoController(PizzaStoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Endereco>>> GetEndereco()
        {
            var endereco = await _db.Endereco.ToListAsync();
            
            return Ok(endereco);
        }
    }
}
