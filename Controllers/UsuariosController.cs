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

    }
}
