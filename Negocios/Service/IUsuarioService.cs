﻿using Datos.DbUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service
{
    public interface IUsuarioService
    {
        Task<bool> Insertar(Usuario modelo);
        Task<bool> Actualizar(Usuario modelo);
        Task<bool> Eliminar(int id);
        Task<Usuario> Obtener(int id);
        Task<IQueryable<Usuario>> ObtTodos();
    }
}
