using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace KHMB
{
    class DB
    {
        static SqlConnection myConnection;
        private static void OpenConnection()
        {
            myConnection = new SqlConnection(
                "Data Source=.;Initial Catalog=Alpha-KHMB;Integrated Security=True"
                );
            myConnection.Open();
        }
        private static void CloseConnection()
        {
            myConnection.Close();
        }
    }

}
