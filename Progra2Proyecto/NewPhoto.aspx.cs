using Progra2Proyecto.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Progra2Proyecto
{
    public partial class NewPhoto : System.Web.UI.Page
    {
        private SqlConnection _connection = ConnectionDB.Get();
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = Request.ServerVariables["SCRIPT_NAME"];
            if (Request.Cookies["user"] == null) Response.Redirect($"/Login.aspx?returnUrl={returnUrl}");
        }

        protected void CreatePhoto_Click(object sender, EventArgs e)
        {            
            try
            {
                if (FilePhoto.HasFile)
                {
                    SqlCommand cmd = _connection.CreateCommand();

                    string command = @"insert Photo(title, [photoFile], [description], createdDate, [owner])
                                    values(@title, @photoFile, @description, @createdDate, @owner)";

                    cmd.CommandText = command;
                    cmd.Parameters.Add("@title", SqlDbType.VarChar, 150).Value = TxtTitle.Text;
                    cmd.Parameters.Add("@photoFile", SqlDbType.Image).Value = FilePhoto.FileBytes;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar, 250).Value = TxtDescription.Text;
                    cmd.Parameters.Add("@createdDate", SqlDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("@owner", SqlDbType.VarChar, 50).Value = Request.Cookies["user"].Value;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    Response.Redirect("/");
                }
                else ErrorMessage.Text = "Debe subir un archivo";              
            }
            catch (Exception)
            {
                
            }         
        }
    }
}
