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
        static SqlConnection myConnection;
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
        public static void InsertRT(string RT)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(
            string.Format("INSERT INTO ResourceType (Name) VALUES (,{0}')", RT), myConnection);
            cmd.ExecuteNonQuery();
        }
    }

}
