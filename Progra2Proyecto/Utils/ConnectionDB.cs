using System.Configuration;
using System.Data.SqlClient;

namespace Progra2Proyecto.Utils
{
    public class ConnectionDB
    {
        public static SqlConnection Get()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBSharePhotos"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
