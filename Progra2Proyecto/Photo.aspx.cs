using Progra2Proyecto.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Progra2Proyecto
{
    public partial class Photo : System.Web.UI.Page
    {
        private SqlConnection _connection = ConnectionDB.Get();
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("/Gallery");
                }
                if (!Page.IsPostBack)
                {
                    var idPhoto = Request.QueryString["id"];
                                        
                    SqlCommand cmd = _connection.CreateCommand();
                    SqlDataReader reader;

                    string _query = "select title, photoFile,[description],[owner],createdDate from Photo where idPhoto = @idPhoto";
                    cmd.CommandText = _query;

                    cmd.Parameters.Add("@idPhoto", SqlDbType.Int).Value = int.Parse(idPhoto);

                    cmd.Connection.Open();
                    reader = cmd.ExecuteReader();                    

                    if (reader.Read())
                    {                        
                        LblTitulo.Text = reader.GetString(0);
                        LblDescription.Text = reader.GetString(2);
                        LblOwner.Text = reader.GetString(3);
                        LblCreatedDate.Text = reader.GetDateTime(4).ToString("d/M/yyyy HH:mm:ss tt");


                        ImgPhoto.ImageUrl = $"data:image/jpg;base64,{Convert.ToBase64String((byte[])reader["photoFile"])}";                
                        
                        if (Request.Cookies["user"] != null && Request.Cookies["user"].Value == reader.GetString(3))
                        {
                            BtnEliminar.Visible = true;                            
                        }
                    }
                    reader.Close();
                    cmd.Connection.Close();

                    string _queryComments = "select * from Comment where idPhoto = @idPhoto order by 1 desc";
                    cmd = _connection.CreateCommand();
                    cmd.CommandText = _queryComments;
                    cmd.Parameters.Add("@idPhoto", SqlDbType.Int).Value = int.Parse(idPhoto);

                    cmd.Connection.Open();

                    reader = cmd.ExecuteReader();
                    ListComments.DataSource = reader;
                    ListComments.DataBind();                    
                    
                    cmd.Connection.Close();                    
                }
            }
			catch (Exception)
			{
			}
        }

        protected void BtnComentario_Click(object sender, EventArgs e)
        {            
            try
            {
                var idPhoto = Request.QueryString["id"];
                if (Request.Cookies["user"] == null) Response.Redirect($"/Login.aspx?returnUrl=/Photo?id={idPhoto}");                
                
                SqlCommand cmd = _connection.CreateCommand();
                string command = @"insert Comment([user],body,createdDate,idPhoto)
                                    values(@user,@body,@createdDate,@idPhoto)";

                cmd = _connection.CreateCommand();
                cmd.CommandText = command;
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = Request.Cookies["user"].Value;
                cmd.Parameters.Add("@body", SqlDbType.VarChar, 150).Value = TxtComment.Text;
                cmd.Parameters.Add("@createdDate", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@idPhoto", SqlDbType.Int).Value = int.Parse(idPhoto);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                SqlDataReader reader;
                string _queryComments = "select * from Comment where idPhoto = @idPhoto order by 1 desc";
                cmd = _connection.CreateCommand();
                cmd.CommandText = _queryComments;
                cmd.Parameters.Add("@idPhoto", SqlDbType.Int).Value = int.Parse(idPhoto);
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                ListComments.DataSource = reader;
                ListComments.DataBind();
                cmd.Connection.Close();

                TxtComment.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var idPhoto = Request.QueryString["id"];                
                SqlCommand cmd = _connection.CreateCommand();

                string _command = "delete from Photo where idPhoto = @idPhoto";

                cmd = _connection.CreateCommand();
                cmd.CommandText = _command;
                cmd.Parameters.Add("@idPhoto", SqlDbType.Int).Value = int.Parse(idPhoto);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Response.Redirect("/Gallery");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                var returnUrl = Request.ServerVariables["SCRIPT_NAME"];
                if (Request.Cookies["user"] == null) Response.Redirect($"/Login.aspx?returnUrl={returnUrl}");
                var idPhoto = Request.QueryString["id"];
                SqlCommand cmd = _connection.CreateCommand();

                string _command = @"insert Favorites (idPhoto,idUser)
                                    select @idPhoto,idUser  from Users where [user] = @user";

                cmd = _connection.CreateCommand();
                cmd.CommandText = _command;
                cmd.Parameters.Add("@idPhoto", SqlDbType.Int).Value = int.Parse(idPhoto);
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = Request.Cookies["user"].Value;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Response.Redirect("/Gallery");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
