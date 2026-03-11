using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticulosNegocio
    {
		AccesoDatos datos = new AccesoDatos();
        public List<Articulos> listado(string id = "")// si escribo asi el paramentro me lo conviente en uno opcional y no obligatorio
        {
                List<Articulos> lista = new List<Articulos>();
                SqlConnection connection = new SqlConnection(); //Objeto creado para la conexion a la DB
                SqlCommand comando = new SqlCommand();//objeto creado para realizar acciones en la conexion que acabamos de declarar
                SqlDataReader Lector;
                try
                {
                    connection.ConnectionString = "server=LUCAS\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true"; //atributo del sqlconnection donde indico a donde me voy a conectar
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "select a.Id, Codigo, Nombre, a.Descripcion, a.IdMarca, m.Descripcion Marca, a.IdCategoria, c.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS a, MARCAS m, CATEGORIAS c where a.IdMarca = m.Id and a.IdCategoria = c.Id ";
                    if (id != "")
                        comando.CommandText += " and a.Id = " + id;
                    comando.Connection = connection;

                    connection.Open();
                    Lector = comando.ExecuteReader();
                    while (Lector.Read())
                    {
                        Articulos aux = new Articulos();
                        aux.Id = (int)Lector["Id"];
                        aux.Codigo = (string)Lector["Codigo"];
                        aux.Nombre = (string)Lector["Nombre"];
                        aux.Descripcion = (string)Lector["Descripcion"];
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)Lector["IdMarca"];
                        aux.Marca.Descripcion = (string)Lector["Marca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)Lector["Categoria"];
                        aux.UrlImagen = (string)Lector["ImagenUrl"];
                        aux.Precio = (decimal)Lector["Precio"];

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
		public List<Articulos> listadoStoredProcedure()
		{
			List<Articulos> lista = new List<Articulos>();
			AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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

		public void Agregar(Articulos nuevo)
		{
			try
			{
				datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria,ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
				datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@IdMarca", nuevo.Marca.Id);
                datos.setearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametros("@Precio", nuevo.Precio);
				datos.ejecutarAccion();
            }
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public void AgregarConSP(Articulos nuevo)
        {
            try
            {
                datos.setearProcedimiento("storedAltaArticulo");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@IdMarca", nuevo.Marca.Id);
                datos.setearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Modificar(Articulos modificar)
		{
			try
			{
				datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @Idmarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
				datos.setearParametros("@Codigo", modificar.Codigo);
				datos.setearParametros("@Nombre", modificar.Nombre);
                datos.setearParametros("@Descripcion", modificar.Descripcion);
                datos.setearParametros("@Idmarca", modificar.Marca.Id);
                datos.setearParametros("@IdCategoria", modificar.Categoria.Id);
                datos.setearParametros("@ImagenUrl", modificar.UrlImagen);
                datos.setearParametros("@Precio", modificar.Precio);
				datos.setearParametros("@Id", modificar.Id);
				datos.ejecutarAccion();
            }
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public void ModificarConSP(Articulos modificar)
        {
            try
            {
                datos.setearProcedimiento("storedModificarArticulo");
                datos.setearParametros("@Codigo", modificar.Codigo);
                datos.setearParametros("@Nombre", modificar.Nombre);
                datos.setearParametros("@Descripcion", modificar.Descripcion);
                datos.setearParametros("@Idmarca", modificar.Marca.Id);
                datos.setearParametros("@IdCategoria", modificar.Categoria.Id);
                datos.setearParametros("@ImagenUrl", modificar.UrlImagen);
                datos.setearParametros("@Precio", modificar.Precio);
                datos.setearParametros("@Id", modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("delete from ARTICULOS where Id = @id");
				datos.setearParametros("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public List<Articulos> Filtrar(string campo, string criterio, string filtro)
        {
			List<Articulos> listar = new List<Articulos>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				string consulta = "select a.Id,Codigo, Nombre, a.Descripcion,a.IdMarca , m.Descripcion Marca,a.Idcategoria,c.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria = c.Id and ";
				if (campo == "Nombre")
				{
                    switch (criterio)
                    {
                        case "Comienza con":
							consulta += "Nombre like '"+ filtro +"%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "' ";
                            break;
						default:
                            consulta += "Nombre like '%" + filtro + "%' ";
                            break;
                    }
                }else if (campo == "Marca")
				{
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "m.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "m.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "m.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
				}
				else
				{
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "c.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "c.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "c.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }
				datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    listar.Add(aux);
                }
                return listar;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public void AgregarFavoritos(int IdUsuario, int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@IdUser, @IdArticulo)");
                datos.setearParametros("@IdUser", IdUsuario);
                datos.setearParametros("@IdArticulo", IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulos> ListarFavorito(int IdUsuario)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select a.Id, Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion Marca, a.IdCategoria, c.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS a, MARCAS m, CATEGORIAS c, FAVORITOS f where a.IdMarca = m.Id and a.IdCategoria = c.Id and a.Id = f.IdArticulo and f.IdUser = @IdUser");
                datos.setearParametros("@IdUser", IdUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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
        public void EliminarFavorito(int IdUsuario,int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdUser = @idUser and IdArticulo = @idArticulo");
                datos.setearParametros("@idUser", IdUsuario);
                datos.setearParametros("@idArticulo", IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool ExisteFavorito(int idArticulo, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdArticulo FROM FAVORITOS WHERE IdArticulo = @IdArticulo AND IdUser = @IdUser");
                datos.setearParametros("@IdArticulo", idArticulo);
                datos.setearParametros("@IdUser", idUsuario);
                datos.ejecutarLectura();

                return datos.Lector.Read();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
