using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Progra2Proyecto
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBSharePhotos"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            SqlDataReader reader;

            string _query = "select * from Photo";
            cmd.CommandText = _query;

            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            
            ListPhotos.DataSource = reader;
            ListPhotos.DataBind();                
        }
    }
}
