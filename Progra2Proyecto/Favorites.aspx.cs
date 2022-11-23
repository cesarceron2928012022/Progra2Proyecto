using Progra2Proyecto.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Progra2Proyecto
{
    public partial class Favorites : System.Web.UI.Page
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

                    string _query = @"select p.* from Photo p
                                        inner join Favorites f on f.idPhoto = p.idPhoto
                                        inner join Users u on u.idUser = f.idUser
                                        where u.[user] = @user
                                        order by p.createdDate desc";
                    cmd.CommandText = _query;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = Request.Cookies["user"].Value;

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
