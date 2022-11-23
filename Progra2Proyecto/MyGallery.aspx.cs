using Progra2Proyecto.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Progra2Proyecto
{
    public partial class MyGallery : System.Web.UI.Page
    {
        private SqlConnection _connection = ConnectionDB.Get();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var returnUrl = Request.ServerVariables["SCRIPT_NAME"];
                if (Request.Cookies["user"] == null) Response.Redirect($"/Login.aspx?returnUrl={returnUrl}");
                if (!Page.IsPostBack)
                {
                    SqlCommand cmd = _connection.CreateCommand();
                    SqlDataReader reader;

                    string _query = "select * from Photo where [owner] = @owner order by createdDate desc";
                    cmd.CommandText = _query;
                    cmd.Parameters.Add("@owner", SqlDbType.VarChar, 50).Value = Request.Cookies["user"].Value;

                    cmd.Connection.Open();
                    reader = cmd.ExecuteReader();

                    ListPhotos.DataSource = reader;
                    ListPhotos.DataBind();
                    cmd.Connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
