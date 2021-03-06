﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.ComponentModel;
using System.Drawing;


namespace KHMB
{
    /// <summary>
    /// Interaction logic for Resource.xaml
    /// </summary>
    public partial class Resource : Window
    {
        int TypeID { get; set; }
        int ResourceID { get; set; }
        string ConnectionStr { get; set; }
        double EnergyComsumption { get; set; }
        public string Query;
        public ComboBox RT;
        public static bool editing;
        public static int editingResourceID;
        public Resource()
        {
            InitializeComponent();
            if (editing == true)
            {
                Btn_Sv.Content = "Save Changes";
            }
            FillCombo();
        }
        void FillCombo()
        {
            // MEMO TO SELF: RETURN LATER TO FIX
            //FJERN IKKE DET HER, IT WORKS, DON'T FIX IT
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Alpha-KHMB;Integrated Security=True");
            string sql = "SELECT* FROM ResourceType";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader myreader;
            //FJERN IKKE DET HER, IT WORKS, DON'T FIX IT
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    int RTID = myreader.GetInt32(0);
                    string sname = myreader.GetString(1);
                    Bx_RT.Items.Add(RTID + " " + sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void CreateResource(int typeID)
        {
        DB.InsertR(Bx_N.Text, typeID);
        }
        public static void EditResourceShow(int ResourceID)
        {
            editing = true;
            Resource nw = new Resource();
            nw.Show();
        }
        private void EditResource(int RTID)
        {
            DB.EditResource(Bx_N.Text,RTID);
            this.Close();
        }
        public void DeleteResource(int IDToDelete)
        {
            DB.Delete("Resource", IDToDelete);
        }

        private void Btn_Sv_Click(object sender, RoutedEventArgs e)
        {
            if (editing == true)
            {
                string RTID = (string)Bx_RT.SelectedValue;
                int ID = Convert.ToInt32(RTID.Substring(0, 2));
                EditResource(ID);
            }
            else if (editing == false)
            {
                string RTID = (string)Bx_RT.SelectedValue;
                int ID = Convert.ToInt32(RTID.Substring(0, 2)); // WE'LL FIX LATER, WE HAVE ISSUES AFTER 99 RESOURCES
                CreateResource(ID);
            }
        }

        private void Bx_RT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_Test_Click(object sender, RoutedEventArgs e)
        {
            FillCombo();
        }
        //public override string ToString()
        //{
        //    return string.Format("Name: {0}", Name);
        //}
    }
}
