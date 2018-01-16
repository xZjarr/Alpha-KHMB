using System;
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

        string Name { get; set; }
        int TypeID { get; set; }
        int ResourceID { get; set; }
        string ConnectionStr { get; set; }
        double EnergyComsumption { get; set; }
        public string Query;
        public ComboBox RT;
        public Resource()
        {
            InitializeComponent();
            FillCombo();
        }
        void FillCombo()
        {
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
                    string sname = myreader.GetString(1);
                    Bx_RT.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static void CreateResource(string name)
        {
            DB.InsertR(name);
        }
        static void EditResource()
        {

        }
        static void DeleteResource()
        {

        }

        private void Btn_Sv_Click(object sender, RoutedEventArgs e)
        {
            CreateResource(Bx_N.Text);
        }

        private void Bx_RT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_Test_Click(object sender, RoutedEventArgs e)
        {
            FillCombo();
        }
    }
}
