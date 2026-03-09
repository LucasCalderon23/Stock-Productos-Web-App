using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            this.Conexion = new SqlConnection("server=LUCAS\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            Comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            try
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = consulta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void setearProcedimiento(string procedimiento)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = procedimiento;
        }

        public void setearParametros(string nombre, object numero)
        {
            Comando.Parameters.AddWithValue(nombre, numero);
        }

        public void ejecutarLectura()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                return int.Parse(Comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if(lector != null)
                lector.Close();
            Conexion.Close();
        }
    }
}
