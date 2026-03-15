using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura;

namespace TPFinalNivel3_Calderon
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuarioActivo"]))
                    {
                        Usuario usuario = (Usuario)Session["usuarioActivo"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        if (!string.IsNullOrEmpty(usuario.UrlImagen))
                            imgPerfil.ImageUrl = "~/Images/" + usuario.UrlImagen;
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = (Usuario)Session["usuarioActivo"];
                    //cargo la imagen y la guado
                    if (txtImagen.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/");
                        txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg");
                        usuario.UrlImagen = "Perfil-" + usuario.Id + ".jpg";
                    }
                    //cargo los demas datos
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    //actualizo los datos mediante el metodo de la clase usuarioNegocio
                    negocio.ActualizarDatos(usuario);
                    //leo la imagen para cargarla en el avatar de la barra de tareas
                    Image img = (Image)Master.FindControl("imgAvatar");
                    img.ImageUrl = "~/Images/" + usuario.UrlImagen;
                
                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}