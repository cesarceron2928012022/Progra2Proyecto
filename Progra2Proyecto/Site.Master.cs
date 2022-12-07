using System;
using System.Web.UI;

namespace Progra2Proyecto
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)        
        {
            if (Request.Cookies["user"] == null) return;
            
            string user = Request.Cookies["user"].Value;
            LblBienvenido.Text = $"Hola {user}";
        }       
    }
}
