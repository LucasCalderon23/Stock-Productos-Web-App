using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Marca> Listado()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            } 
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarMarca(Marca nuevo)
        {
            try
            {
                datos.setearConsulta("insert into MARCAS (Descripcion) values (@Descripcion)");
                datos.setearParametros("@Descripcion", nuevo.Descripcion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }
}
