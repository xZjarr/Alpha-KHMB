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
        public double cost;
        public TimeSpan startTime;
        public TimeSpan endTime;
        public static bool editing = false;
        public static int editingTarifID;
        public Tarif()
        {
            InitializeComponent();
            if (editing == true)
            {
                btn_TariffCreate.Content = "Save changes";
            }
            fillStartDropDown();
            fillEndDropDown();
        }

        private void fillStartDropDown()
        {
            CheckAvailable();
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
        public static void EditShow(double cost, TimeSpan start, TimeSpan End, int ID)
        {
            Tarif nw = new Tarif();
            nw.Show();
        }
        //By Klaus
        public void Delete(int IDToDelete)
        {
            DB.DeleteTarifESP("Tarif", IDToDelete);
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
            if (editing == true)
            {
                DB.EditTarif(txtBox_TariffValue.Text, drpBox_TariffStartClock.Text, drpBox_TariffEndClock.Text);
                this.Close();
            }
            else if (editing == false)
            {
                DB.InsertTariff(txtBox_TariffValue.Text, drpBox_TariffStartClock.Text, drpBox_TariffEndClock.Text);
                this.Close();
            }
        }

        private void txtBox_TariffValue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
