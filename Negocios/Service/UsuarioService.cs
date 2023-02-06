using Datos.DbUsuarios;
using Datos.DbUsuarios.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> usuRepository;
        public UsuarioService(IGenericRepository<Usuario> usuRepository)
        {
            this.usuRepository = usuRepository;
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            return await usuRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await usuRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await usuRepository.Insertar(modelo);
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await usuRepository.Obtener(id);
        }
        
        public async Task<IQueryable<Usuario>> ObtTodos()
        {
            return await usuRepository.ObtTodos();
        }
    }
}
