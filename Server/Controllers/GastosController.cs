using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
          private readonly Context _context;

        public GastosController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gastos>>> GetGastos()
        {
            if (_context.Gastos == null)
            {
                return NotFound();
            }
            return await _context.Gastos.ToListAsync();
        }


         [HttpGet("{GastosId}")]
        public async Task<ActionResult<Gastos>> GetGastos(int id)
        {
            if (_context.Gastos == null)
            {
                return NotFound();
            }
            var gastos = await _context.Gastos.FindAsync(id);

            if (gastos == null)
            {
                return NotFound();
            }

            return gastos;
        }

        [HttpPost]
        public async Task<ActionResult<Gastos>> PostEntradas(Gastos gastos)
        {
            if(!Existe(gastos.GastosId))
            {
                _context.Gastos.Add(gastos);
            }
            else
            {
                _context.Gastos.Update(gastos);
            }

            await _context.SaveChangesAsync();
            return Ok(gastos);
        }

        [HttpDelete("{GastosId}")]
        public async Task<IActionResult> EliminarGasto(int GastosId)
        {
            if(_context.Gastos == null)
            {
                return NotFound();
            }

            var gasto = await _context.Gastos.FindAsync(GastosId);

            if(gasto == null)
            {
                return NotFound();
            }

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool Existe(int id)
        {
            return (_context.Gastos?.Any(e => e.GastosId == id)).GetValueOrDefault();
        }
    }
}