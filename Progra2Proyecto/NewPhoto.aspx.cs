using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace Progra2Proyecto
{
    public partial class NewPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = Request.ServerVariables["SCRIPT_NAME"];
            if (Request.Cookies["user"] == null) Response.Redirect($"/Login.aspx?returnUrl={returnUrl}");
        }

        protected void CreatePhoto_Click(object sender, EventArgs e)
        {            
            try
            {
                if (!FilePhoto.HasFile) ErrorMessage.Text = "Debe subir un archivo";

                string extension = Path.GetExtension(FilePhoto.FileName);
                if (extension != ".jpg" && extension != ".jpeg" && extension != "png")
                    ErrorMessage.Text = "Debe subir un archivo";

                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
                FilePhoto.SaveAs(Server.MapPath("~/Photos/") + fileName);

                string connectionString = ConfigurationManager.ConnectionStrings["DBSharePhotos"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = connection.CreateCommand();

                string command = @"insert Photo(title, [photoFile], [description], createdDate, [owner])
                                    values(@title, @photoFile, @description, @createdDate, @owner)";                

                cmd.CommandText = command;
                cmd.Parameters.Add("@title", SqlDbType.VarChar, 150).Value = TxtTitle.Text;
                cmd.Parameters.Add("@photoFile", SqlDbType.VarChar, 150).Value = fileName;
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 250).Value = TxtDescription.Text;
                cmd.Parameters.Add("@createdDate", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@owner", SqlDbType.VarChar, 50).Value = Request.Cookies["user"].Value;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                
                cmd.Connection.Close();

                Response.Redirect("/");
            }
            catch (Exception)
            {
                
            }         
        }
    }
}
