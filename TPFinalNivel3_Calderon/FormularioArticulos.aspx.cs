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
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            txtId.Enabled = false;
            try
            {
                if(!IsPostBack)
                {
                    //Cargo los DropDownList con la informacion de la DB
                    List<Marca> listaMarca = marcaNegocio.Listado();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    List<Categoria> listaCategoria = categoriaNegocio.Listado();
                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }

                //capturo el id que envie anteriormente por URL para saber si hay un articulo seleccionado o no
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id != "" && !IsPostBack)
                {
                    //como ya se que negocio.listado me devuelve una lista, cargo ese unico elemento que vino por URL (id) en la lista y 
                    //lo guardo en la variable seleccionado
                    Articulos seleccionado = (negocio.listado(id))[0];//me devuelve el elemento que este en la posicion 0 de la lista

                    //precargo los datos del articulo seleccionado
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagen.Text = seleccionado.UrlImagen;
                    txtImagen_TextChanged(sender, e);

                }
                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            //cuando cargo la textbox con la url de la imagen y se la guardo a la caja de imagen
            imgProducto.ImageUrl = txtImagen.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Articulos nuevo = new Articulos();
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                //cargo los datos de las textbox en la variable 'nuevo'
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.UrlImagen = txtImagen.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.ModificarConSP(nuevo);
                }
                else
                {
                    negocio.AgregarConSP(nuevo);
                }

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.asxp",false);
            }
        }
    }
}