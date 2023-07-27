using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasBancariasController : ControllerBase
    {
        private static List<CuentasBancarias> cuentasBancarias = new List<CuentasBancarias>();

        // GET: api/cuentasbancarias
        [HttpGet]
        public ActionResult<IEnumerable<CuentasBancarias>> GetCuentasBancarias()
        {
            return cuentasBancarias;
        }

        // GET: api/cuentasbancarias/5
        [HttpGet("{id}")]
        public ActionResult<CuentasBancarias> GetCuentasBancarias(int id)
        {
            var cuentaBancaria = cuentasBancarias.Find(c => c.Id == id);
            if (cuentaBancaria == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cuenta bancaria
            }
            return cuentaBancaria;
        }

        // POST: api/cuentasbancarias
        [HttpPost]
        public ActionResult<CuentasBancarias> PostCuentasBancarias(CuentasBancarias cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }

            // Genera un nuevo ID para la cuenta bancaria
            cuentaBancaria.Id = cuentasBancarias.Count + 1;
            cuentasBancarias.Add(cuentaBancaria);

            return CreatedAtAction(nameof(GetCuentasBancarias), new { id = cuentaBancaria.Id }, cuentaBancaria);
        }

        // PUT: api/cuentasbancarias/5
        [HttpPut("{id}")]
        public IActionResult PutCuentasBancarias(int id, CuentasBancarias cuentaBancaria)
        {
            if (id != cuentaBancaria.Id)
            {
                return BadRequest(); // Devuelve 400 si el ID proporcionado no coincide con el ID de la cuenta bancaria
            }

            var index = cuentasBancarias.FindIndex(c => c.Id == id);
            if (index == -1)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cuenta bancaria
            }

            // Actualiza los datos de la cuenta bancaria
            cuentasBancarias[index].NombreBanco = cuentaBancaria.NombreBanco;
            cuentasBancarias[index].NumeroCuenta = cuentaBancaria.NumeroCuenta;
            cuentasBancarias[index].SaldoActual = cuentaBancaria.SaldoActual;

            return NoContent(); // Devuelve 204 para indicar que la actualización fue exitosa
        }

        // DELETE: api/cuentasbancarias/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCuentasBancarias(int id)
        {
            var cuentaBancaria = cuentasBancarias.Find(c => c.Id == id);
            if (cuentaBancaria == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cuenta bancaria
            }

            cuentasBancarias.Remove(cuentaBancaria);

            return NoContent(); // Devuelve 204 para indicar que la cuenta bancaria fue eliminada exitosamente
        }
    }
}
