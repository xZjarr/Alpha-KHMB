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
    /// Interaction logic for ShowList.xaml
    /// </summary>
    public partial class ShowList : Window
    {
        public ShowList(string chosenObject)
        {
            InitializeComponent();
            lbl_Title.Content = chosenObject;
            if (chosenObject == "ResourceTypes")
            {
                ShowResourceType();
            }
            else if (chosenObject == "Resources")
            {
                //ShowResource();
                //ShowResourceType();
            }

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow returnWindow = new MainWindow();
            returnWindow.Show();
            this.Close();
        }
        private void ShowResourceType()
        {
            List<RTO> rt = DB.SelectAllResourceTypes();
            listbox_Show.ItemsSource = rt;
        }
        //private void ShowResource()
        //{
        //    List<RO> r = DB.SelectAllResource();
        //    listbox_Show.ItemsSource = r;
        //}
    }
}
