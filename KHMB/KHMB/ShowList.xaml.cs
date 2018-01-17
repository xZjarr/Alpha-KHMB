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
            string chosenO = chosenObject;
            InitializeComponent();
            lbl_Title.Content = chosenObject;
            if (chosenObject == "ResourceTypes")
            {
                ShowResourceType();
            }
            else if (chosenObject == "Resources")
            {
                ShowResource();
                ShowResourceType();
            }
            else if (chosenObject == "Jobs")
            {
                ShowJob();
            }
            else if (chosenObject == "Users")
            {
                ShowUsers();
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
        private void ShowResource()
        {
            List<RO> r = DB.SelectAllResource();
            listbox_Show.ItemsSource = r;
        }
        private void ShowJob()
        {
            List<JobO> job = DB.SelectAllJobs();
            listbox_Show.ItemsSource = job;
        }
        private void ShowUsers()
        {
            List<UserO> users = DB.SelectAllUsers();
            listbox_Show.ItemsSource = users;
        }

        private void listbox_Show_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox_Show.GetType == )
            { 
            JobO chosenJob = (JobO)listbox_Show.SelectedItem;
            SelectedTempJob.ChosenJob = chosenJob;
            ShowDetails sdJ = new ShowDetails();
            sdJ.Show();
            this.Close();
            }
            //UserO chosenUser = (UserO)listbox_Show.SelectedItem;
            //SelectedTempUser.ChosenUser = chosenUser;
            //ShowDetails sdU = new ShowDetails();
            //sdU.Show();
            //this.Close();
        }

        //private void ShowTarif()
        //{
        //    List<__> tarif = DB.SelectAllTarifs();
        //    listbox_Show.ItemsSource = tarif;
        //}
        //private void ShowESPs()
        //{
        //    List<__> esps = DB.SelectAllEsps();
        //    listbox_Show.ItemsSource = esps;
        //}

    }
}
