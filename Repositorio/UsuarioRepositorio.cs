using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuarioDbContext _context;
        public UsuarioRepositorio(UsuarioDbContext context) 
        {
            _context = context;
        }
        public void Add(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public void Remove(long id)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
            _context.Usuarios.Remove(user);
            _context.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _context.Usuarios.Update(user);
            _context.SaveChanges();
        }
    }
}
