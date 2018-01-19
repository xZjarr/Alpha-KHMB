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
    /// <summary>
    /// Interaction logic for ResourceType.xaml
    /// </summary>
    public partial class ResourceType : Window
    {
        //<List> Resources
        public static bool editing = false;
        public static int EditResourceTypeID;
        public ResourceType()
        { 
            InitializeComponent();
            if (editing == true)
            {
                Btn_Save.Content = "Save Changes";
            }
        }
        public void GetResources(int ID)
        {

        }
        public void CreateResourceType(string RTName)
        {
            DB.InsertRT(RTName);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (editing == false)
            {
                CreateResourceType(Bx_Nm.Text);
                this.Close();
            }
            else if (editing == true)
            {
                Edit();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public static void EditShow(int RTID)
        {
            ResourceType nw = new ResourceType();
            nw.Show();
        }
        private void Edit()
        {
            DB.EditResourceType(Bx_Nm.Text);
        }
        public void Delete(int IDToDelete)
        {
            DB.Delete("ResourceType", IDToDelete);
        }
    }
}
