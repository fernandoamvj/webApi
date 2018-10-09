using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Repositorio;
namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuariosController:Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
                return NotFound();
            return new ObjectResult(usuario);
        } 
        [HttpPost]
        public IActionResult Create ([FromBody] Usuario user)
        {
            if (user == null)
                return BadRequest();
            _usuarioRepositorio.Add(user);
            return CreatedAtRoute("GetUsuario", new { id = user.UsuarioId }, user);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuario user)
        {
            if (user == null || user.UsuarioId != id)
                return BadRequest();
            var _usuario = _usuarioRepositorio.Find(id);
            if (_usuario == null)
                return NotFound();
            _usuario.Email = user.Email;
            _usuario.Nome = user.Nome;
            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
                return NotFound();
            _usuarioRepositorio.Remove(id);
            return new NoContentResult();
        }

    }
}
