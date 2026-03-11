using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinalNivel3_Calderon
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; } = new List<Articulos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["usuarioActivo"] != null)
                    {
                        ArticulosNegocio negocio = new ArticulosNegocio();
                        Usuario usuario = (Usuario)Session["usuarioActivo"];
                        if (Request.QueryString["id"] != null)
                        {
                            int idArticulo = int.Parse(Request.QueryString["id"]);
                            negocio.EliminarFavorito(usuario.Id, idArticulo);
                            Response.Redirect("Favoritos.aspx", false);
                        }
                        else
                        {
                            ListaArticulos = negocio.ListarFavorito(usuario.Id);
                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }
    }
}