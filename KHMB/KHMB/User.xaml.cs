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

namespace KHMB
{
    public partial class User : Window
    {
        Random rnd = new Random();
        string UserName, Password, FirstName, SurName;
        int UserID;
        bool IsAdmin, LogInSucces;
        public User()
        {
            InitializeComponent();
        }
        public void CreateUser(string FrstName, string SrNm, string Psswrd, bool IsDmn)
        {
            string UserName = CreateUserName(FrstName);
            DB.InsertUser(FrstName, SrNm, Psswrd, IsDmn, UserName);
        }
        public void EditUser(int UserID)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Is_Admin.IsChecked == true)
            {
                IsAdmin = true;
                Convert.ToInt32(IsAdmin);
            }
            if (Btn_Is_Admin.IsChecked == false)
            {
                IsAdmin = false;
                Convert.ToInt32(IsAdmin);
            }
            CreateUser(Bx_FrstNm.Text, Bx_SrNm.Text, Bx_PssWrd.Text, IsAdmin);
            this.Close();
        }

        public void DeleteUser()
        {

        }
        public bool CheckJob()
        {
            return IsAdmin;
        }
        public void CheckAviableUserName()
        {

        }
        public bool LogIn(string UserName, string Password)
        {
            return LogInSucces;
        }
        private string CreateUserName(string firstName)
            {
            string UserName;
            int UserID = rnd.Next(100, 999);
            UserName = firstName.Substring(0,4) + UserID.ToString();
            return UserName;
            }
    }
}
