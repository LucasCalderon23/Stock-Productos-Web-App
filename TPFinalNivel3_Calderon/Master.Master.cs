using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Infraestructura;

namespace TPFinalNivel3_Calderon
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login) && !(Page is Default) && !(Page is RegistroUsuario))
            {
                if (!Seguridad.sesionActiva(Session["usuarioActivo"]))
                    Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.sesionActiva(Session["usuarioActivo"]))
            {
                Usuario usuario = (Usuario)Session["usuarioActivo"];
                lblUser.Text = usuario.Email;
                imgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["usuarioActivo"]).UrlImagen;
            }
            else
            {
                imgAvatar.ImageUrl = "https://imgs.search.brave.com/X_N2Y1fS1TO5CbzKSvt1Wsfs7lyyC_oefR6wrHHdPaU/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy84/Lzg5L1BvcnRyYWl0/X1BsYWNlaG9sZGVy/LnBuZw";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnMiPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroUsuario.aspx", false);
        }
    }
}