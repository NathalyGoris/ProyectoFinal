using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuarios> usuarios = new List<Usuarios>();

        // GET: api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetUsuarios()
        {
            return usuarios;
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public ActionResult<Usuarios> GetUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.ID == id);
            if (usuario == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el usuario
            }
            return usuario;
        }

        // POST: api/usuarios
        [HttpPost]
        public ActionResult<Usuarios> PostUsuario(Usuarios usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }

            // Genera un nuevo ID para el usuario
            usuario.ID = usuarios.Count + 1;
            usuarios.Add(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.ID }, usuario);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuarios usuario)
        {
            if (id != usuario.ID)
            {
                return BadRequest(); // Devuelve 400 si el ID proporcionado no coincide con el ID del usuario
            }

            var existingUsuario = usuarios.FirstOrDefault(u => u.ID == id);
            if (existingUsuario == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el usuario
            }

            // Actualiza los datos del usuario
            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.Correo = usuario.Correo;
            existingUsuario.Contrasena = usuario.Contrasena;

            return NoContent(); // Devuelve 204 para indicar que la actualización fue exitosa
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.ID == id);
            if (usuario == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el usuario
            }

            usuarios.Remove(usuario);

            return NoContent(); // Devuelve 204 para indicar que el usuario fue eliminado exitosamente
        }
    }

