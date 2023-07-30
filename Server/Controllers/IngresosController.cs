using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
          private readonly Context _context;

        public IngresosController(Context context)
        {
            _context = context;
        }
         public async Task<ActionResult<IEnumerable<Ingresos>>> GetIngresos()
        {
            if (_context.Ingresos == null)
            {
                return NotFound();
            }
            return await _context.Ingresos.ToListAsync();
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Ingresos>> GetIngresos(int id)
        {
            if (_context.Ingresos == null)
            {
                return NotFound();
            }
            var ingresos = await _context.Ingresos.FindAsync(id);

            if (ingresos == null)
            {
                return NotFound();
            }

            return ingresos;
        }

        // POST: api/categoriasgastos
        [HttpPost]
        public async Task<ActionResult<Ingresos>> PostIngresos(Ingresos ingresos)
        {
            if (!IngresosExists(ingresos.TransaccionId))
                _context.Ingresos.Add(ingresos);
            else
                _context.Ingresos.Update(ingresos);

            await _context.SaveChangesAsync();
            return Ok(ingresos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngresos(int id)
        {
            if (_context.Ingresos == null)
            {
                return NotFound();
            }
            var ingresos = await _context.Ingresos.FindAsync(id);
            if (ingresos == null)
            {
                return NotFound();
            }

            _context.Ingresos.Remove(ingresos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresosExists(int id)
        {
            return (_context.Ingresos?.Any(e => e.TransaccionId == id)).GetValueOrDefault();
        }
    }
}