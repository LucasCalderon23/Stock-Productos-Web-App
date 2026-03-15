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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(!Page.IsValid)
            {
                return;
            }
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                if(negocio.Login(usuario));
                {
                    Session.Add("usuarioActivo", usuario);
                    Response.Redirect("Default.aspx", false);
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