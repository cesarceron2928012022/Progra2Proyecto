using System;

namespace Progra2Proyecto
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                Request.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
                Request.Cookies["user"].Value = string.Empty;
            }                        

            Request.Cookies.Clear();            
        }
    }
}
