using Progra2Proyecto.Utils;
using System;
using System.Data.SqlClient;

namespace Progra2Proyecto
{
    public partial class Gallery : System.Web.UI.Page
    {
        private SqlConnection _connection = ConnectionDB.Get();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = _connection.CreateCommand();
                SqlDataReader reader;

                string _query = "select * from Photo";
                cmd.CommandText = _query;

                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                ListPhotos.DataSource = reader;
                ListPhotos.DataBind();
                cmd.Connection.Close();
            }                              
        }

    }
}
