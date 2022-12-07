using Progra2Proyecto.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Progra2Proyecto
{
    public partial class Register : System.Web.UI.Page
    {
        private SqlConnection _connection = ConnectionDB.Get();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {                                
                SqlCommand cmd = _connection.CreateCommand();
                SqlDataReader reader;

                string _query = "select * from Users where [user] = @user ";
                cmd.CommandText = _query;
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = User.Text;

                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LblError.Text = "Usuario ya se encuentra registrado";
                    return;
                }
                reader.Close();
                string command = @"insert Users([user], [name],[password])
                                values(@user,@name, @password)";

                cmd = _connection.CreateCommand();
                cmd.CommandText = command;
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = User.Text;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = Name.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = Password.Text.GetSHA256();

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Response.Redirect("/Login");
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
            
        }
    }
}
