using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPFinalNivel3_Calderon
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            dgvListaArticulos.DataSource = negocio.listadoStoredProcedure();
            dgvListaArticulos.DataBind();
        }

        protected void dgvListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?id=" + id);
        }

        protected void dgvListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaArticulos.PageIndex = e.NewPageIndex;
            dgvListaArticulos.DataBind();
        }
    }
}