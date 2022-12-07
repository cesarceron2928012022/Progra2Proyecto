using Progra2Proyecto.Utils;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Progra2Proyecto
{
    public partial class _Default : Page
    {
        private SqlConnection _connection = ConnectionDB.Get();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = _connection.CreateCommand();
                SqlDataReader reader;

                string _query = "select top 3 * from Photo order by createdDate desc";
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
