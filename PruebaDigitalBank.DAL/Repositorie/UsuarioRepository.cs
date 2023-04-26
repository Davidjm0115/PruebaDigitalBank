using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PruebaDigitalBank.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalBank.DAL.Repositorie
{
    public class UsuarioRepository : IGenericRepository<Usuario>
    {
        private readonly IDbConnection _db;

        public UsuarioRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            var result = await _db.QueryAsync<Usuario>("SP_CRUD_Usuarios", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var result = await _db.QueryAsync<Usuario>("SP_CRUD_Usuarios", new { Action = "GetById", Id = id }, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<bool> InsertarUsuario(Usuario usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "Insert");
            parameters.Add("@Nombre", usuario.Nombre);
            parameters.Add("@FechaNacimiento", usuario.FechaNacimiento);
            parameters.Add("@Sexo", usuario.Sexo);

            var result = await _db.ExecuteAsync("SP_CRUD_Usuarios", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "Update");
            parameters.Add("@Id", usuario.Id);
            parameters.Add("@Nombre", usuario.Nombre);
            parameters.Add("@FechaNacimiento", usuario.FechaNacimiento);
            parameters.Add("@Sexo", usuario.Sexo);

            var result = await _db.ExecuteAsync("SP_CRUD_Usuarios", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "Delete");
            parameters.Add("@Id", id);

            var result = await _db.ExecuteAsync("SP_CRUD_Usuarios", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}


