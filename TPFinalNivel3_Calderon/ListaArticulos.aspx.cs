using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Infraestructura;
namespace TPFinalNivel3_Calderon
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuarioActivo"]))
            {
                Session.Add("Error", "Se requieren permisos para estar en esta pagina");
                Response.Redirect("Error.aspx", false);
            }
            FiltroAvanzado = ckdFiltro.Checked;
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Session.Add("listaArticulos", negocio.listadoStoredProcedure());
                dgvListaArticulos.DataSource = Session["listaArticulos"];
                dgvListaArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void dgvListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = dgvListaArticulos.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioArticulos.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void dgvListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaArticulos.PageIndex = e.NewPageIndex;
            dgvListaArticulos.DataBind();
        }
        protected void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = ckdFiltro.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada = lista.FindAll(x => 
            x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.Marca.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.Categoria.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvListaArticulos.DataSource = listaFiltrada;
            dgvListaArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Nombre")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
            else if (ddlCampo.SelectedItem.ToString() == "Marca")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                dgvListaArticulos.DataSource = negocio.Filtrar(ddlCampo.SelectedItem.ToString(), 
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                dgvListaArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                dgvListaArticulos.DataSource = negocio.listadoStoredProcedure();
                dgvListaArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}