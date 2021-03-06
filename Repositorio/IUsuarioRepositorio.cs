﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario Find(long id);
        void Remove(long id);
        void Update(Usuario user);
    }
}
