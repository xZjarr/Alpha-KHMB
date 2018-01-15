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
        string NameUsrInput { get; set; }
        int ID { get; set; }
        //<List> Resources
        bool Access;
        public ResourceType()
        {
                InitializeComponent();
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
            CreateResourceType(Bx_Nm.Text);
            this.Close();
        }
    }
}
