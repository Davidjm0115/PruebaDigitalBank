using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Repositorios
{
    public interface IUsuarioRepository
    {
    
         IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int id);
        void InsertarUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);


    }
}
