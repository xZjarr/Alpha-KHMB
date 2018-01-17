﻿using System;
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
        
        public static void InsertUser(string FrstName, string SrNm, string Psswrd, bool IsDmn, string UserName)
        {
            OpenConnection();
            SqlCommand insertRName = new SqlCommand("INSERT INTO [User] (UserName, Password, Name, Surname, IsAdmin) VALUES (@UserName,@Password,@Name,@SurName,@IsAdmin)", myConnection);
            insertRName.Parameters.Add("@UserName", SqlDbType.VarChar);
            insertRName.Parameters["@UserName"].Value = UserName;
            insertRName.Parameters.Add("@Password", SqlDbType.VarChar);
            insertRName.Parameters["@Password"].Value = Psswrd;
            insertRName.Parameters.Add("@Name", SqlDbType.VarChar);
            insertRName.Parameters["@Name"].Value = FrstName;
            insertRName.Parameters.Add("@Surname", SqlDbType.VarChar);
            insertRName.Parameters["@Surname"].Value = SrNm;
            insertRName.Parameters.Add("@IsAdmin", SqlDbType.VarChar);
            insertRName.Parameters["@IsAdmin"].Value = IsDmn;
            insertRName.ExecuteNonQuery();
        }
        public static void InsertR(string R, int RTID)
        {
            OpenConnection();
            SqlCommand insertRName = new SqlCommand("INSERT INTO Resource (TypeID,name) VALUES (@TypeID,@name)", myConnection);
            insertRName.Parameters.Add("@TypeID", SqlDbType.Int);
            insertRName.Parameters["@TypeID"].Value = RTID;
            insertRName.Parameters.Add("@name", SqlDbType.VarChar);
            insertRName.Parameters["@name"].Value = R;
            insertRName.ExecuteNonQuery();
            //SqlCommand insertRName = new SqlCommand("INSERT INTO Resource (name) VALUES (@name)", myConnection);

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
        public static List<RO> SelectAllResource()
        {
            List<RO> rList = new List<RO>();
            OpenConnection();
            SqlCommand getR = new SqlCommand("SELECT * FROM Resource", myConnection);
            SqlDataReader reader = getR.ExecuteReader();
            while (reader.Read())
            {
                RO r = new RO();
                r.Name = reader.GetString(1);
                rList.Add(r);
            }
            CloseConnection();
            return rList;
        }
        public static List<JobO> SelectAllJobs()
        {
            List<JobO> jList = new List<JobO>();
            OpenConnection();
            SqlCommand getJ = new SqlCommand("SELECT * FROM Job", myConnection);
            SqlDataReader reader = getJ.ExecuteReader();
            while (reader.Read())
            {
                JobO j = new JobO();
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
        public static List<UserO> SelectAllUsers()
        {
            List<UserO> uList = new List<UserO>();
            OpenConnection();
            SqlCommand getU = new SqlCommand("SELECT * FROM [User]", myConnection);
            SqlDataReader reader = getU.ExecuteReader();
            while (reader.Read())
            {
                UserO u = new UserO();
                u.FirstName = reader.GetString(3);
                u.SurName = reader.GetString(4);
                u.UserName = reader.GetString(1);
                u.IsAdmin = reader.GetBoolean(5);
                uList.Add(u);
            }
            CloseConnection();
            return uList;
        }

        public static List<JobO> FillQueue(int resource)
        {
            //Get jobs to add to the queue
            List<JobO> queueJobs = new List<JobO>();
            OpenConnection();
            SqlCommand getJobs = new SqlCommand("SELECT * FROM Job WHERE ResourceID = @resource", myConnection);
            getJobs.Parameters.Add("@resource", SqlDbType.Int);
            getJobs.Parameters["@resource"].Value = resource;
            SqlDataReader reader = getJobs.ExecuteReader();
            while (reader.Read())
            {
                JobO j = new JobO();
                //j.ExeTime = reader.GetDateTime(2);
                queueJobs.Add(j);
            }
            CloseConnection();
            return queueJobs;
        }

        public static void InsertJob(JobO jobToAdd)
        {
            OpenConnection();
            SqlCommand insertJob = new SqlCommand("INSERT INTO Job ([Name],[ResourceID],[CreatedByUserID],[Deadline],[Created],[Priority],[ExecutionTime])VALUES(@name,@resource,@UserID,@exeTime,'2017-01-01 00:00:00',1,'2018-01-01 00:00:00'); ", myConnection);
            insertJob.Parameters.Add("@name", SqlDbType.VarChar);
            insertJob.Parameters["@name"].Value = jobToAdd.JobName;
            insertJob.Parameters.Add("@resource", SqlDbType.Int);
            insertJob.Parameters["@resource"].Value = jobToAdd.ResourceID;
            insertJob.Parameters.Add("@userID", SqlDbType.Int);
            insertJob.Parameters["@userID"].Value = jobToAdd.CreatedUserID;
            insertJob.Parameters.Add("@exeTime", SqlDbType.DateTime);
            insertJob.Parameters["@exeTime"].Value = jobToAdd.ExeTime;
            insertJob.ExecuteNonQuery();
            CloseConnection();
        }
    }
}