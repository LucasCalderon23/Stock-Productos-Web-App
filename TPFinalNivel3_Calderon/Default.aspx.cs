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
            if (!IsPostBack)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Session["listaArticulos"] = negocio.listadoStoredProcedure();
            }

            ListaArticulos = (List<Articulos>)Session["listaArticulos"];
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
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

        
    }
}