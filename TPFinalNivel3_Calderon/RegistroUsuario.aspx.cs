using Dominio;
using Infraestructura;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Calderon
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) 
                {
                    return;
                }

                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                user.Id = negocio.crearNuevo(user);
                Session.Add("usuarioActivo", user);

                emailService.armarCorreo(user.Email, "Bienvenido!!!", "Hola, te has registrado exitosamente");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}