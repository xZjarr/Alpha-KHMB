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
            CloseConnection();
        }

        internal static List<JobO> SelectExecutedJobs()
        {

            List<JobO> jList = new List<JobO>();
            DateTime Finished;

            OpenConnection();
            SqlCommand getJ = new SqlCommand("  SELECT * FROM Job WHERE (DATEADD(hh,durationhours,ExecutionTime) < getdate())", myConnection);
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

        internal static List<ESPO> GetESPs(DateTime now, DateTime endDate)
        {
            List<ESPO> eList = new List<ESPO>();
            OpenConnection();
            SqlCommand getESP = new SqlCommand("SELECT DISTINCT * FROM ESP WHERE (StartDate > @startDate OR StartDate < @endDate) OR (EndDate > @startDate OR EndDate < @endDate) ORDER BY EnergySurplus DESC", myConnection);
            getESP.Parameters.Add("@startDate", SqlDbType.DateTime);
            getESP.Parameters["@startDate"].Value = now;
            getESP.Parameters.Add("@endDate", SqlDbType.DateTime);
            getESP.Parameters["@endDate"].Value = endDate;
            SqlDataReader reader = getESP.ExecuteReader();
            while (reader.Read())
            {
                ESPO e = new ESPO();
                e.StartDate = reader.GetDateTime(1);
                e.EndDate = reader.GetDateTime(2);
                e.StartTime = reader.GetTimeSpan(3);
                e.EndTime = reader.GetTimeSpan(4);
                e.EnergySurplus = reader.GetDouble(5);
                eList.Add(e);
            }
            CloseConnection();
            return eList;
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

        internal static bool IsResourceAvailable(DateTime possibleStart, DateTime soonestEnd, JobO currentJob)
        {
            bool available = true;
            OpenConnection();
            SqlCommand getJ = new SqlCommand("SELECT DISTINCT ExecutionTime FROM Job WHERE ResourceID=@ResourceID AND ( (DATEADD(hour, DurationHours, ExecutionTime)>@PossibleStart AND DATEADD(hour, DurationHours, ExecutionTime)>@SoonestEnd) OR (ExecutionTime<=@PossibleStart AND ExecutionTime>@SoonestEnd) )", myConnection);
            getJ.Parameters.Add("@ResourceID", SqlDbType.Int);
            getJ.Parameters["@ResourceID"].Value = currentJob.ResourceID;
            getJ.Parameters.Add("@PossibleStart", SqlDbType.DateTime);
            getJ.Parameters["@PossibleStart"].Value = possibleStart;
            getJ.Parameters.Add("@SoonestEnd", SqlDbType.DateTime);
            getJ.Parameters["@SoonestEnd"].Value = soonestEnd;
            SqlDataReader reader = getJ.ExecuteReader();
            if(reader.Read())
            {
                DateTime executionTime = reader.GetDateTime(0);
                available = false;
            }
            CloseConnection();
            return available;
        }

        internal static UserO GetUser(int createdUserID)
        {
            UserO u = new UserO();
            OpenConnection();
            SqlCommand getU = new SqlCommand("SELECT * FROM [User] WHERE UserID=@UserId", myConnection);
            getU.Parameters.Add("@UserID", SqlDbType.Int);
            getU.Parameters["@UserID"].Value = createdUserID;
            SqlDataReader reader = getU.ExecuteReader();
            if (reader.Read())
            {
                
                u.FirstName = reader.GetString(3);
                u.SurName = reader.GetString(4);
                u.UserName = reader.GetString(1);
                u.IsAdmin = reader.GetBoolean(5);
                u.Password = reader.GetString(2);
                u.UserID = reader.GetInt32(0);
            }
            CloseConnection();
            return u;
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

        public static void InsertESP(string ESP_Surplus, string ESP_StartClock, string ESP_EndClock, string ESP_StartDate, string ESP_EndDate)
        {
            OpenConnection();
            SqlCommand insertRT = new SqlCommand("INSERT INTO ESP (EnergySurplus, StartTime, EndTime, StartDate, EndDate) VALUES (@surplus, @startClock, @endClock, @startDate, @endDate)", myConnection);
            insertRT.Parameters.Add("@surplus", SqlDbType.Float);
            insertRT.Parameters["@surplus"].Value = float.Parse(ESP_Surplus);
            insertRT.Parameters.Add("@startClock", SqlDbType.Time);
            insertRT.Parameters["@startClock"].Value = TimeSpan.Parse(ESP_StartClock);
            insertRT.Parameters.Add("@endClock", SqlDbType.Time);
            insertRT.Parameters["@endClock"].Value = TimeSpan.Parse(ESP_EndClock);
            insertRT.Parameters.Add("@startDate", SqlDbType.DateTime);
            insertRT.Parameters["@startDate"].Value = DateTime.Parse(ESP_StartDate);
            insertRT.Parameters.Add("@endDate", SqlDbType.DateTime);
            insertRT.Parameters["@endDate"].Value = DateTime.Parse(ESP_EndDate);
            insertRT.ExecuteNonQuery();
            CloseConnection();
        }

        public static void InsertTariff(string Tariff_Value, string Tariff_StartClock, string Tariff_EndClock)
        {
            OpenConnection();
            SqlCommand insertRT = new SqlCommand("INSERT INTO Tarif (Price, StartTime, EndTime) VALUES (@cost, @startClock, @endClock)", myConnection);
            insertRT.Parameters.Add("@cost", SqlDbType.Float);
            insertRT.Parameters["@cost"].Value = float.Parse(Tariff_Value);
            insertRT.Parameters.Add("@startClock", SqlDbType.Time);
            insertRT.Parameters["@startClock"].Value = TimeSpan.Parse(Tariff_StartClock);
            insertRT.Parameters.Add("@endClock", SqlDbType.Time);
            insertRT.Parameters["@endClock"].Value = TimeSpan.Parse(Tariff_EndClock);
            insertRT.ExecuteNonQuery();
            CloseConnection();
        }

        public static List<TO> SelectAllTarifs()
        {
            List<TO> tList = new List<TO>();
            OpenConnection();
            SqlCommand getT = new SqlCommand("SELECT * FROM Tarif", myConnection);
            SqlDataReader reader = getT.ExecuteReader();
            while (reader.Read())
            {
                TO t = new TO();
                t.StartTime = reader.GetTimeSpan(1);
                t.EndTime = reader.GetTimeSpan(2);
                t.Cost = reader.GetDouble(3);
                t.TarifID = reader.GetInt32(0);
                tList.Add(t);
            }
            CloseConnection();
            return tList;
        }
        public static List<ESPO> SelectAllESP()
        {
            List<ESPO> eList = new List<ESPO>();
            OpenConnection();
            SqlCommand getESP = new SqlCommand("SELECT * FROM ESP", myConnection);
            SqlDataReader reader = getESP.ExecuteReader();
            while (reader.Read())
            {
                ESPO e = new ESPO();
                e.StartDate = reader.GetDateTime(1);
                e.EndDate = reader.GetDateTime(2);
                e.StartTime = reader.GetTimeSpan(3);
                e.EndTime = reader.GetTimeSpan(4);
                e.EnergySurplus = reader.GetDouble(5);
                e.ESP_ID = reader.GetInt32(0);
                eList.Add(e);
            }
            CloseConnection();
            return eList;
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
                rt.ResourceTypeID = reader.GetInt32(0);
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
                r.ResourceID = reader.GetInt32(2);
                rList.Add(r);
            }
            CloseConnection();
            return rList;
        }
        public static List<RO> SelectAllResource(int resourceTypeId)
        {
            List<RO> rList = new List<RO>();
            OpenConnection();
            SqlCommand getR = new SqlCommand("SELECT * FROM Resource", myConnection);
            SqlDataReader reader = getR.ExecuteReader();
            while (reader.Read())
            {
                RO r = new RO();
                r.Name = reader.GetString(1);
                r.ResourceID = reader.GetInt32(2);
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
                u.Password = reader.GetString(2);
                u.UserID = reader.GetInt32(0);
                uList.Add(u);
            }
            CloseConnection();
            return uList;
        }

        //By Klaus
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
                j.ExeTime = reader.GetDateTime(7);
                queueJobs.Add(j);
            }
            CloseConnection();
            return queueJobs;
        }

        //By Klaus
        public static bool InsertJob(JobO jobToAdd)
        {
            OpenConnection();
            try
            {
                SqlCommand insertJob = new SqlCommand("INSERT INTO Job ([Name],[ResourceID],[CreatedByUserID],[Deadline],[Created],[Priority],[ExecutionTime],[DurationHours])VALUES(@name,@resource,@UserID,@deadline,@creation,@priority,@exeTime,@duration); ", myConnection);
                insertJob.Parameters.Add("@name", SqlDbType.VarChar);
                insertJob.Parameters["@name"].Value = jobToAdd.JobName;
                insertJob.Parameters.Add("@resource", SqlDbType.Int);
                insertJob.Parameters["@resource"].Value = jobToAdd.ResourceID;
                insertJob.Parameters.Add("@userID", SqlDbType.Int);
                insertJob.Parameters["@userID"].Value = jobToAdd.CreatedUserID;
                insertJob.Parameters.Add("@deadline", SqlDbType.DateTime);
                insertJob.Parameters["@deadline"].Value = jobToAdd.Deadline;
                insertJob.Parameters.Add("@creation", SqlDbType.DateTime);
                insertJob.Parameters["@creation"].Value = jobToAdd.Created;
                insertJob.Parameters.Add("@priority", SqlDbType.TinyInt);
                insertJob.Parameters["@priority"].Value = jobToAdd.Priority;
                insertJob.Parameters.Add("@exeTime", SqlDbType.DateTime);
                insertJob.Parameters["@exeTime"].Value = jobToAdd.ExeTime;
                insertJob.Parameters.Add("@duration", SqlDbType.Int);
                insertJob.Parameters["@duration"].Value = jobToAdd.DurationHours;
                insertJob.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool LogIn(string UserName, string password)
        {
            CurrentUser UserLogIn = new CurrentUser();
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT UserID, IsAdmin FROM [User] WHERE UserName=@UserName AND Password=@Password", myConnection);
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            cmd.Parameters["@UserName"].Value = UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            cmd.Parameters["@Password"].Value = password;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CurrentUser.ID = reader.GetInt32(0);
                CurrentUser.IsAdmin = reader.GetBoolean(1);
                CurrentUser.UserName = UserName;
                CurrentUser.Password = password;
                CloseConnection();

                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }

        //Klaus
        public static bool Delete(string callerClass, int callerID)
        {
            OpenConnection();
            try
            {
                string tablestring = "[" + callerClass + "]";
                string iDColumn = callerClass + "ID";
                SqlCommand delete = new SqlCommand("DELETE FROM " + tablestring + " WHERE " + iDColumn + " = @ID;", myConnection);
                delete.Parameters.Add("@ID", SqlDbType.Int);
                delete.Parameters["@ID"].Value = callerID;
                delete.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception)
            {
                CloseConnection();
                return false;
            }
        }
        public static void EditUser(string FrstName, string SrNm, string Psswrd, bool IsDmn, int EditUserId)
        {
            try
            {
                OpenConnection();
                SqlCommand UpdateUser = new SqlCommand("UPDATE [User] SET Password=@Password, Name=@Name, Surname=@Surname, IsAdmin=@IsAdmin WHERE UserID=@UserID", myConnection);
                UpdateUser.Parameters.Add("@Password", SqlDbType.VarChar);
                UpdateUser.Parameters["@Password"].Value = Psswrd;
                UpdateUser.Parameters.Add("@Name", SqlDbType.VarChar);
                UpdateUser.Parameters["@Name"].Value = FrstName;
                UpdateUser.Parameters.Add("@Surname", SqlDbType.VarChar);
                UpdateUser.Parameters["@Surname"].Value = SrNm;
                UpdateUser.Parameters.Add("@IsAdmin", SqlDbType.VarChar);
                UpdateUser.Parameters["@IsAdmin"].Value = IsDmn;
                UpdateUser.Parameters.Add("@UserID", SqlDbType.Int);
                UpdateUser.Parameters["@UserID"].Value = EditUserId;
                UpdateUser.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }
        public static void EditJob (int ResourceID,int JobID, int UserId, int Prio, DateTime Deadline)
        {
            OpenConnection();
            SqlCommand UpdateUser = new SqlCommand("UPDATE [Job] SET DeadLine=@DeadLine, Priority=@Priority, ResourceID=@ResourceID WHERE JobID=@JobID", myConnection);
            UpdateUser.Parameters.Add("@DeadLine", SqlDbType.DateTime);
            UpdateUser.Parameters["@DeadLine"].Value = Deadline;
            UpdateUser.Parameters.Add("@Priority", SqlDbType.TinyInt);
            UpdateUser.Parameters["@Priority"].Value = Prio;
            UpdateUser.Parameters.Add("@ResourceID", SqlDbType.Int);
            UpdateUser.Parameters["@ResourceID"].Value = ResourceID;
            UpdateUser.Parameters.Add("@JobID", SqlDbType.Int);
            UpdateUser.Parameters["@JobID"].Value = JobID;
            UpdateUser.ExecuteNonQuery();
            CloseConnection();
        }
        public static void EditResource(string resourceName, int resourceTypeID)
        {
            OpenConnection();
            SqlCommand UpdateUser = new SqlCommand("UPDATE [Resource] SET [Name]=@Name, TypeID=@TypeID WHERE ResourceID=@ResourceID", myConnection);
            UpdateUser.Parameters.Add("@Name", SqlDbType.VarChar);
            UpdateUser.Parameters["@Name"].Value = resourceName;
            UpdateUser.Parameters.Add("@TypeID", SqlDbType.Int);
            UpdateUser.Parameters["@TypeID"].Value = resourceTypeID;
            UpdateUser.Parameters.Add("@ResourceID", SqlDbType.Int);
            UpdateUser.Parameters["@ResourceID"].Value = Resource.editingResourceID;
            UpdateUser.ExecuteNonQuery();
            CloseConnection();
        }
        //Klaus
        public static bool DeleteTarifESP(string callerClass, int callerID)
        {
            //Var nødt til at have egen metode, da deres ID kolonne var navngivet anderledes
            OpenConnection();
            try
            {
                string tablestring = "[" + callerClass + "]";
                SqlCommand delete = new SqlCommand("DELETE FROM " + tablestring + " WHERE ID = @ID;", myConnection);
                delete.Parameters.Add("@ID", SqlDbType.Int);
                delete.Parameters["@ID"].Value = callerID;
                delete.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception)
            {
                CloseConnection();
                return false;
            }
        }
    }
}
