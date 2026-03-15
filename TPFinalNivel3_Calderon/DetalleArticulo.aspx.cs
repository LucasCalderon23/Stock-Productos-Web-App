using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPFinalNivel3_Calderon
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"]);

                        ArticulosNegocio negocio = new ArticulosNegocio();
                        List<Articulos> lista = negocio.listado();

                        Articulos seleccionado = lista.Find(x => x.Id == id);

                        lblNombre.Text = seleccionado.Nombre;
                        lblMarca.Text = seleccionado.Marca.Descripcion;
                        lblDescripcion.Text = seleccionado.Descripcion;
                        lblPrecio.Text = "$" + seleccionado.Precio.ToString();
                        imgImagenDetalle.ImageUrl = seleccionado.UrlImagen;

                        Usuario usuario = (Usuario)Session["usuarioActivo"];
                        bool favorito = negocio.ExisteFavorito(id, usuario.Id);
                        if (favorito)
                        {
                            btnFavorito.Text = "Quitar de Favoritos";
                        }
                        else
                        {
                            btnFavorito.Text = "Agregar a Favoritos";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
           
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        
        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    int idArticulo = int.Parse(Request.QueryString["id"]);
                    Usuario usuario = (Usuario)Session["usuarioActivo"];
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    if (negocio.ExisteFavorito(idArticulo, usuario.Id))
                    {
                        negocio.EliminarFavorito(usuario.Id, idArticulo);
                    }
                    else
                    {
                        negocio.AgregarFavoritos(usuario.Id, idArticulo);
                    }
                    Response.Redirect("DetalleArticulo.aspx?id=" + idArticulo, false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }
    
    }
}