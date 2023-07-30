using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private static List<Transacciones> transacciones = new List<Transacciones>();

        // GET: api/transacciones
        [HttpGet]
        public ActionResult<IEnumerable<Transacciones>> GetTransacciones()
        {
            return transacciones;
        }

        // GET: api/transacciones/5
        [HttpGet("{id}")]
        public ActionResult<Transacciones> GetTransaccion(int id)
        {
            var transaccion = transacciones.FirstOrDefault(t => t.TransaccionId == id);
            if (transaccion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la transacción
            }
            return transaccion;
        }

        // POST: api/transacciones
        [HttpPost]
        public ActionResult<Transacciones> PostTransaccion(Transacciones transaccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }

            // Genera un nuevo ID para la transacción
            transaccion.TransaccionId = transacciones.Count + 1;
            transacciones.Add(transaccion);

            return CreatedAtAction(nameof(GetTransaccion), new { id = transaccion.TransaccionId }, transaccion);
        }

        // PUT: api/transacciones/5
        [HttpPut("{id}")]
        public IActionResult PutTransaccion(int id, Transacciones transaccion)
        {
            if (id != transaccion.TransaccionId)
            {
                return BadRequest(); // Devuelve 400 si el ID proporcionado no coincide con el ID de la transacción
            }

            var existingTransaccion = transacciones.FirstOrDefault(t => t.TransaccionId == id);
            if (existingTransaccion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la transacción
            }

            // Actualiza los datos de la transacción
            existingTransaccion.Fecha = transaccion.Fecha;
            existingTransaccion.Monto = transaccion.Monto;
            existingTransaccion.Descripcion = transaccion.Descripcion;
            existingTransaccion.Usuario = transaccion.Usuario;
            existingTransaccion.Categoria = transaccion.Categoria;

            return NoContent(); // Devuelve 204 para indicar que la actualización fue exitosa
        }

        // DELETE: api/transacciones/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTransaccion(int id)
        {
            var transaccion = transacciones.FirstOrDefault(t => t.TransaccionId == id);
            if (transaccion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la transacción
            }

            transacciones.Remove(transaccion);

            return NoContent(); // Devuelve 204 para indicar que la transacción fue eliminada exitosamente
        }
    }
}
