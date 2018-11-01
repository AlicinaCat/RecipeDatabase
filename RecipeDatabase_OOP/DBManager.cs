using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RecipeDatabase_OOP
{
    class DBManager
    {
        private string ConnectionString { get; set; }
        private SqlConnection Connection = null;
        private SqlCommand Command = null;
        private string Query;

        public DBManager(string query)
        {
            ConnectionString = "Data Source=localhost;Initial Catalog=RecipeDatabase;Integrated Security=SSPI;";
            Connection = new SqlConnection(ConnectionString);
            Query = query;
        }

        public DataTable ExecuteSQL()
        {
            DataTable table = new DataTable();

            using (Connection)
            {
                Connection.Open();

                Command = new SqlCommand(Query, Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(Command);
                adapter.Fill(table);
            }

            return table;
        }

        public int ExecuteSQLScalar()
        {
            int result;

            using (Connection)
            {
                Connection.Open();

                Command = new SqlCommand(Query, Connection);
                result = Convert.ToInt32(Command.ExecuteScalar());
            }

            return result;
        }

        public void ExecuteSQLNoReturn()
        {
            using (Connection)
            {
                Connection.Open();

                Command = new SqlCommand(Query, Connection);
                Command.ExecuteNonQuery();
            }
        }
    }
}
