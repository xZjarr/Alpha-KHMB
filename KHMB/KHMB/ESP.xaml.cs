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
    /// Interaction logic for ESP.xaml
    /// </summary>
    public partial class ESP : Window
    {
        public ESP()
        {
            InitializeComponent();
            fillStartDropDown();
            fillEndDropDown();

        }

        private void fillStartDropDown()
        {
            for (int hour = 0; hour <= 24; hour++)
            {
                drpBox_ESPStartClock.Items.Add(hour + ":00");
                if (hour < 24)
                {
                    drpBox_ESPStartClock.Items.Add(hour + ":15");
                    drpBox_ESPStartClock.Items.Add(hour + ":30");
                    drpBox_ESPStartClock.Items.Add(hour + ":45");
                }
            }

        }

        private void fillEndDropDown()
        {
            for (int hour = 0; hour <= 24; hour++)
            {
                drpBox_ESPEndClock.Items.Add(hour + ":00");
                if (hour < 24)
                {
                    drpBox_ESPEndClock.Items.Add(hour + ":15");
                    drpBox_ESPEndClock.Items.Add(hour + ":30");
                    drpBox_ESPEndClock.Items.Add(hour + ":45");
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
        static void GetESPs()
        {

        }

        private void btn_ESPCreate_Click(object sender, RoutedEventArgs e)
        {
            DB.InsertESP(txtBox_ESPValue.Text, drpBox_ESPStartClock.Text, drpBox_ESPEndClock.Text, datePicker_ESPStartDate.Text, datePicker_ESPEndDate.Text);
            this.Close();
        }

        private void drpBox_ESPEndClock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
