using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion( string valor)
        {
            _connectionString = valor;
        }
        
        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection( _connectionString);
            conexion.Open();
            return conexion;
        }


    }
}
