using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasGastosController : ControllerBase
    {
        private static List<CategoriaGastos> categoriasGastos = new List<CategoriaGastos>();

        // GET: api/categoriasgastos
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaGastos>> GetCategoriasGastos()
        {
            return categoriasGastos;
        }

        // GET: api/categoriasgastos/5
        [HttpGet("{id}")]
        public ActionResult<CategoriaGastos> GetCategoriaGasto(int id)
        {
            var categoriaGasto = categoriasGastos.FirstOrDefault(c => c.ID == id);
            if (categoriaGasto == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la categoría de gasto
            }
            return categoriaGasto;
        }

        // POST: api/categoriasgastos
        [HttpPost]
        public ActionResult<CategoriaGastos> PostCategoriaGasto(CategoriaGastos categoriaGastos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }

            // Genera un nuevo ID para la categoría de gasto
            categoriaGastos.ID = categoriasGastos.Count + 1;
            categoriasGastos.Add(categoriaGastos);

            return CreatedAtAction(nameof(GetCategoriaGasto), new { id = categoriaGastos.ID }, categoriaGastos);
        }

        // PUT: api/categoriasgastos/5
        [HttpPut("{id}")]
        public IActionResult PutCategoriaGasto(int id, CategoriaGastos categoriaGastos)
        {
            if (id != categoriaGastos.ID)
            {
                return BadRequest(); // Devuelve 400 si el ID proporcionado no coincide con el ID de la categoría de gasto
            }

            var existingCategoriaGastos = categoriasGastos.FirstOrDefault(c => c.ID == id);
            if (existingCategoriaGastos == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la categoría de gasto
            }

            // Actualiza los datos de la categoría de gasto
            existingCategoriaGastos.Nombre = categoriaGastos.Nombre;

            return NoContent(); // Devuelve 204 para indicar que la actualización fue exitosa
        }

        // DELETE: api/categoriasgastos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoriaGasto(int id)
        {
            var categoriaGastos = categoriasGastos.FirstOrDefault(c => c.ID == id);
            if (categoriaGastos == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la categoría de gasto
            }

            categoriasGastos.Remove(categoriaGastos);

            return NoContent(); // Devuelve 204 para indicar que la categoría de gasto fue eliminada exitosamente
        }
    }
}
