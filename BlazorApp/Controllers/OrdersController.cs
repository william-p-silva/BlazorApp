using BlazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Dados;


namespace BlazorApp.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaStoreContext _db;
        public OrdersController(PizzaStoreContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(Pedido pedido)
        {
            pedido.DataCriacao = DateTime.Now;

            foreach (var pizza in pedido.Pizzas)
            {
                _db.Entry(pizza).State = EntityState.Unchanged;
            }

            _db.Pedidos.Add(pedido);
            await _db.SaveChangesAsync();

            return pedido.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> GetPedidos()
        {
            var pedidos = await _db.Pedidos
                .Include(p => p.Pizzas)
                .OrderByDescending(p => p.DataCriacao)
                .ToListAsync();
            return pedidos;

        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Pedido>> GetOrderWithStatus(int orderId)
        {
            var pedido = await _db.Pedidos
                .Where(o => o.Id == orderId)
                .Include(o => o.Pizzas)
                .SingleOrDefaultAsync();
            if(pedido == null)
            {
                return NotFound();
            }
            return pedido;
        }
    }
}
