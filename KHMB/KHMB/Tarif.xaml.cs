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
    /// Interaction logic for Tarif.xaml
    /// </summary>
    public partial class Tarif : Window
    {
        public Tarif()
        {
            InitializeComponent();
            DateTime StartDate; //including StartTime
            DateTime EndDate; //Including EndTime
            Double EnergyCost;
            fillStartDropDown();
            fillEndDropDown();
        }

        private void fillStartDropDown()
        {
            for (int hour = 0; hour <= 24; hour++)
            {
                drpBox_TariffStartClock.Items.Add(hour + ":00");
                if (hour < 24)
                {
                    drpBox_TariffStartClock.Items.Add(hour + ":15");
                    drpBox_TariffStartClock.Items.Add(hour + ":30");
                    drpBox_TariffStartClock.Items.Add(hour + ":45");
                }
            }

        }

        private void fillEndDropDown()
        {
            for (int hour = 0; hour <= 24; hour++)
            {
                drpBox_TariffEndClock.Items.Add(hour + ":00");
                if (hour < 24)
                {
                    drpBox_TariffEndClock.Items.Add(hour + ":15");
                    drpBox_TariffEndClock.Items.Add(hour + ":30");
                    drpBox_TariffEndClock.Items.Add(hour + ":45");
                }
            }

        }

        static void Create()
        {

        }
        static void Edit()
        {

        }
        static void Delete()
        {

        }
        // (StartDate, EndDate)
        static void CheckAvailable()
        {

        }
        // (StartDate, EndDate)
        static void GetTariffs()
        {

        }

        private void btn_TariffCreate_Click(object sender, RoutedEventArgs e)
        {
            DB.InsertTariff(txtBox_TariffValue.Text, drpBox_TariffStartClock.Text, drpBox_TariffEndClock.Text);
            this.Close();
        }
    }
}
