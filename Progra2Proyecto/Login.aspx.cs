﻿using Progra2Proyecto.Utils;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Progra2Proyecto
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBSharePhotos"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            SqlDataReader reader;

            string _query = "select * from Users where [user] = @user and [password] = @password";
            cmd.CommandText = _query;            

            cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = TxtUser.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = TxtPassword.Text.GetSHA256();

            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //Agregamos una sesion de usuario
                //Session["usuariologueado"] = TxtUser.Text;
                Response.Redirect("/");                
            }
            else LblError.Text = "Error de Usuario o Contraseña";            
            cmd.Connection.Close();
        }
    }
}
