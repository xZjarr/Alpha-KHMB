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
        public Tarif()
        {
            InitializeComponent();
            fillStartDropDown();
            fillEndDropDown();
        }

        private void fillStartDropDown()
        {
            CheckAvailable();
            for (int hour = 00; hour < 24; hour++)
            {
                drpBox_TariffStartClock.Items.Add(hour + ":00");
                
            }

        }

        private void fillEndDropDown()
        {
            for (int hour = 00; hour < 24; hour++)
            {
                drpBox_TariffEndClock.Items.Add(hour + ":00");
               
            }

        }
        public static void Edit(double cost, TimeSpan start, TimeSpan End)
        {

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
            DB.InsertTariff(txtBox_TariffValue.Text, drpBox_TariffStartClock.Text, drpBox_TariffEndClock.Text);
            this.Close();
        }
    }
}
