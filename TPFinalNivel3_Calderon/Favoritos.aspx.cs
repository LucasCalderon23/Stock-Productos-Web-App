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
        public List<Articulos> ListaArticulos {  get; set; }
        public bool Favorito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}