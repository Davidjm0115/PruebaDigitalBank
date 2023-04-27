using PruebaDigitalBank.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalBank.DAL.Repositorie
{
    public interface IUsuarioRepository<TEntityModel> where TEntityModel : class
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<bool> InsertarUsuario(Usuario usuario);
        Task<bool> ActualizarUsuario(Usuario usuario);
        Task<bool> EliminarUsuario(int id);



    }
}
