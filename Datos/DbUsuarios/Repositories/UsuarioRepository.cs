using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DbUsuarios.Repositories
{
    public class UsuarioRepository : IGenericRepository<Usuario> //por medio de la implementacion de interfaz se agregaron las funciones que alli se crearon
    {
        private readonly DbusuariosContext _dbcontext;//referencia a la base de datos que indica que solo se usa para lectura por medio de  "readonly"
        public UsuarioRepository(DbusuariosContext context) //se escribe ctor y se da doble tabulacion para agregar el constructor
        {
            _dbcontext = context;

        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            _dbcontext.Usuarios.Update(modelo);
            await _dbcontext.SaveChangesAsync(); //guardar cambios de manera asincrona
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Usuario modelo = _dbcontext.Usuarios.First(c => c.IdUsuario == id); //obtenemos el id del modelo de usuario
            _dbcontext.Usuarios.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _dbcontext.Usuarios.FindAsync(id);
        }
        public async Task<IQueryable<Usuario>> ObtTodos()
        {
            IQueryable<Usuario> queryUsuarioSQL = _dbcontext.Usuarios;
            return queryUsuarioSQL;
        }
    }
}
