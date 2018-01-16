using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace KHMB
{
    class DB
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

        public static void InsertR(string R)
        {
            OpenConnection();
            SqlCommand insertR = new SqlCommand("INSERT INTO Resource (name) VALUES (@name)", myConnection);
            insertR.Parameters.Add("@name", SqlDbType.VarChar);
            insertR.Parameters["@name"].Value = R;
            insertR.ExecuteNonQuery();
            CloseConnection();
        }
        public static void InsertRT(string RT)
        {
            OpenConnection();
            SqlCommand insertRT = new SqlCommand("INSERT INTO ResourceType (name) VALUES (@name)", myConnection);
            insertRT.Parameters.Add("@name", SqlDbType.VarChar);
            insertRT.Parameters["@name"].Value = RT;
            insertRT.ExecuteNonQuery();
            CloseConnection();
        }
        public static List<RTO> SelectAllResourceTypes()
        {
            List<RTO> rtList = new List<RTO>();
            OpenConnection();
            SqlCommand getRT = new SqlCommand("SELECT * FROM ResourceType", myConnection);
            SqlDataReader reader = getRT.ExecuteReader();
            while (reader.Read())
            {
                RTO rt = new RTO();
                rt.Name = reader.GetString(1);
                rtList.Add(rt);
            }
            CloseConnection();
            return rtList;
        }
        ////public static List<RO> SelectAllResource()
        //{
        //    List<RO> rList = new List<RO>();
        //    OpenConnection();
        //    SqlCommand getR = new SqlCommand("SELECT * FROM Resource", myConnection);
        //    SqlDataReader reader = getR.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        RO r = new RO();
        //        r.Name = reader.GetString(1);
        //        rList.Add(r);
        //    }
        //    CloseConnection();
        //    return rList;
        //}

        public static List<Job> FillQueue(int resource)
        {
            //Get jobs to add to the queue
            List<Job> queueJobs = new List<Job>();
            OpenConnection();
            SqlCommand getJobs = new SqlCommand("SELECT * FROM Job WHERE ResourceID = @resource", myConnection);
            getJobs.Parameters.Add("@resource", SqlDbType.Int);
            getJobs.Parameters["@resource"].Value = resource;
            SqlDataReader reader = getJobs.ExecuteReader();
            while (reader.Read())
            {
                Job j = new Job();
                j.Priority = reader.GetByte(0);
                queueJobs.Add(j);
            }
            CloseConnection();
            return queueJobs;
        }
    }
}
