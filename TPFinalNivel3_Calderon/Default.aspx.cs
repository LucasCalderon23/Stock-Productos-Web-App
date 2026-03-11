using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPFinalNivel3_Calderon
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    Session["listaArticulos"] = negocio.listadoStoredProcedure();
                    if (Request.QueryString["id"] != null)
                    {
                        if (Session["usuarioActivo"] != null)
                        {
                            int idArticulo = int.Parse(Request.QueryString["id"]);
                            Usuario usuario = (Usuario)Session["usuarioActivo"];
                            negocio.AgregarFavoritos(usuario.Id, idArticulo);
                            Response.Redirect("Default.aspx", false);

                        } else
                        {
                            Response.Redirect("Login.aspx", false);
                         }
                    
                    }
                }
                ListaArticulos = (List<Articulos>)Session["listaArticulos"];
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Erro.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];

                string filtro = txtFiltro.Text.ToLower();

                List<Articulos> listaFiltrada = lista.FindAll(x =>
                    x.Nombre.ToLower().Contains(filtro) ||
                    x.Descripcion.ToLower().Contains(filtro) ||
                    x.Marca.Descripcion.ToLower().Contains(filtro) ||
                    x.Categoria.Descripcion.ToLower().Contains(filtro)
                );

                ListaArticulos = listaFiltrada;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Erro.aspx", false);
            }

           
        }

        
    }
}