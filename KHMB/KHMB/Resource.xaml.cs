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
    /// Interaction logic for Resource.xaml
    /// </summary>
    public partial class Resource : Window
    {

        string Name { get; set; }
        int TypeID { get; set; }
        int ResourceID { get; set; }
        string ConnectionStr { get; set; }
        double EnergyComsumption { get; set; }
        public Resource()
        {
            InitializeComponent();
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
    }
}
