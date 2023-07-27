using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaAhorrosController : ControllerBase
    {
        private static List<MetaAhorros> metasAhorros = new List<MetaAhorros>();

        // GET: api/metasahorro
        [HttpGet]
        public ActionResult<IEnumerable<MetaAhorros>> GetMetasAhorro()
        {
            return metasAhorros;
        }

        // GET: api/metasahorro/5
        [HttpGet("{id}")]
        public ActionResult<MetaAhorros> GetMetaAhorro(int id)
        {
            var metaAhorro = metasAhorros.FirstOrDefault(m => m.Id == id);
            if (metaAhorro == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la meta de ahorro
            }
            return metaAhorro;
        }

        // POST: api/metasahorro
        [HttpPost]
        public ActionResult<MetaAhorros> PostMetaAhorro(MetaAhorros metaAhorros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }

            // Genera un nuevo ID para la meta de ahorro
            metaAhorros.Id = metasAhorros.Count + 1;
            metasAhorros.Add(metaAhorros);

            return CreatedAtAction(nameof(GetMetaAhorro), new { id = metaAhorros.Id }, metaAhorros);
        }

        // PUT: api/metasahorro/5
        [HttpPut("{id}")]
        public IActionResult PutMetaAhorro(int id, MetaAhorros metaAhorros)
        {
            if (id != metaAhorros.Id)
            {
                return BadRequest(); // Devuelve 400 si el ID proporcionado no coincide con el ID de la meta de ahorro
            }

            var existingMetaAhorro = metasAhorros.FirstOrDefault(m => m.Id == id);
            if (existingMetaAhorro == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la meta de ahorro
            }

            // Actualiza los datos de la meta de ahorro
            existingMetaAhorro.MontoObjetivo = metaAhorros.MontoObjetivo;
            existingMetaAhorro.FechaLimite = metaAhorros.FechaLimite;

            return NoContent(); // Devuelve 204 para indicar que la actualización fue exitosa
        }

        // DELETE: api/metasahorro/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMetaAhorro(int id)
        {
            var metaAhorro = metasAhorros.FirstOrDefault(m => m.Id == id);
            if (metaAhorro == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la meta de ahorro
            }

            metasAhorros.Remove(metaAhorro);

            return NoContent(); // Devuelve 204 para indicar que la meta de ahorro fue eliminada exitosamente
        }
    }
}
