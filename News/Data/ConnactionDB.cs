using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using News.Models;
using System.Data;

namespace News.Data
{
    public class ConnactionDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        public List<User> GetUsers()
        {
            List<User> usersList = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "select * from dbo.USERS with(nolock)";
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable drUsers = new DataTable();


            }
                return usersList;
        }
    }
}
