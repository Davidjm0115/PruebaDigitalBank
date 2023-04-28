using CapaDatos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexion _conexion;
        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@opcion", "UPDATE");
                parametros.Add("@Id", usuario.Id);
                parametros.Add("@Nombre", usuario.Nombre);
                parametros.Add("@FechaNacimiento", usuario.FechaNacimiento);
                parametros.Add("@Sexo", usuario.Sexo);
                conexion.Execute("SP_CRUD_Usuarios", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void EliminarUsuario(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@opcion", "DELETE");
                parametros.Add("@Id",id);
                conexion.Execute("SP_CRUD_Usuarios", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@opcion", "SELECTID");
                return conexion.Query<Usuario>("SP_CRUD_Usuarios", parametros, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }
        public Usuario GetUsuarioById(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@opcion", "SELECTID");
                parametros.Add("@Id", id);
                return conexion.QueryFirstOrDefault<Usuario>("SP_CRUD_Usuarios", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void InsertarUsuario(Usuario usuario)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@opcion", "INSERT");
                parametros.Add("@Nombre", usuario.Nombre);
                parametros.Add("@FechaNacimiento", usuario.FechaNacimiento);
                parametros.Add("@Sexo", usuario.Sexo);
                conexion.Execute("SP_CRUD_Usuarios", parametros, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
