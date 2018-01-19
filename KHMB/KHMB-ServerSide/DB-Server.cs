using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace KHMB_ServerSide
{
    class DB_Server
    {
        public static SqlConnection myConnection;
        public static void OpenConnection()
        {
            myConnection = new SqlConnection(
                "Data Source=.;Initial Catalog=Alpha-KHMB;Integrated Security=True"
                );
            myConnection.Open();
        }

        public static void CloseConnection()
        {
            myConnection.Close();
        }

        internal static RO GetResource(int resourceID)
        {
            RO r = new RO();
            OpenConnection();
            SqlCommand getR = new SqlCommand("SELECT * FROM Resource WHERE ResourceID=@ResourceID", myConnection);
            getR.Parameters.Add("@ResourceID", SqlDbType.Int);
            getR.Parameters["@ResourceID"].Value = resourceID;
            SqlDataReader reader = getR.ExecuteReader();
            if (reader.Read())
            {
                r.Name = reader.GetString(1);
                r.ResourceID = reader.GetInt32(2);
            }
            CloseConnection();
            return r;
        }

        internal static List<JobO> SelectJobsToBeExecuted()
        {

            List<JobO> jList = new List<JobO>();

            OpenConnection();
            SqlCommand getJ = new SqlCommand("  SELECT * FROM Job WHERE ExecutionTime < DATEADD(second,30,getdate()) AND  ExecutionTime > DATEADD(second,-30,getdate())", myConnection);
            SqlDataReader reader = getJ.ExecuteReader();
            while (reader.Read())
            {
                JobO j = new JobO();
                j.JobID = reader.GetInt32(0);
                j.JobName = reader.GetString(6);
                j.Priority = reader.GetByte(5);
                j.ResourceID = reader.GetInt32(1);
                j.Deadline = reader.GetDateTime(3);
                j.Created = reader.GetDateTime(4);
                j.CreatedUserID = reader.GetInt32(2);
                jList.Add(j);
            }
            CloseConnection();
            return jList;
        }

    }
}
