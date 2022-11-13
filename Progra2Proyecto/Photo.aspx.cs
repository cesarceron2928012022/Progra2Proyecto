using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Progra2Proyecto
{
	public partial class Photo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (!Page.IsPostBack)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DBSharePhotos"].ConnectionString;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand cmd = connection.CreateCommand();
                    SqlDataReader reader;

                    string _query = "select title, photoFile,[description] from Photo where idPhoto = 6";
                    cmd.CommandText = _query;

                    cmd.Connection.Open();
                    reader = cmd.ExecuteReader();                    

                    if (reader.Read())
                    {
                        LblTitulo.Text = reader.GetString(0);
                        LblDescription.Text = reader.GetString(2);
                        ImgPhoto.ImageUrl = $"/Photos/{reader.GetString(1)}";
                    }                    
                }
            }
			catch (Exception)
			{
			}
        }
    }
}
