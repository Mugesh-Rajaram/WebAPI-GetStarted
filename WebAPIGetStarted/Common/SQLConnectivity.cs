using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAPIGetStarted.Common
{
    public class SQLConnectivity
    {
        public const string connectionString = "";

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        public static DataSet GetData()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adaper = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from user_details nolock";
            adaper.SelectCommand = cmd;
            adaper.Fill(ds);
            connection.Close();

            return ds;
        }
    }
}