using PruebaDigitalBank.DAL.DataContext;
using PruebaDigitalBank.DAL.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalBank.BLL.Service
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            var result = await _usuarioRepository.GetAllUsuarios();
            return result;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var result = await _usuarioRepository.GetUsuarioById(id);
            return result;
        }

        public async Task<bool> InsertarUsuario(Usuario usuario)
        {
            var result = await _usuarioRepository.InsertarUsuario(usuario);
            return result;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var result = await _usuarioRepository.ActualizarUsuario(usuario);
            return result;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var result = await _usuarioRepository.EliminarUsuario(id);
            return result;
        }
    }
}
