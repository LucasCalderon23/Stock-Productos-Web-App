using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Categoria> Listado()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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

        public void AgregarCategoria(Categoria nuevo)
        {
            try
            {
                datos.setearConsulta("insert into CATEGORIAS (Descripcion) values (@Descripcion)");
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
