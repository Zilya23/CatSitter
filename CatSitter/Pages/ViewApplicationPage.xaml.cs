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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.DataBase;
using Core.Functions;

namespace CatSitter.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewApplicationPage.xaml
    /// </summary>
    public partial class ViewApplicationPage : Page
    {
        public static Applictioon application {get; set;}
        public ViewApplicationPage(Applictioon applictioon)
        {
            InitializeComponent();
            application = applictioon;

            tbDate.Text = " с " + application.StartDate.ToString().Split(' ')[0] + " по " + application.EndDate.ToString().Split(' ')[0];

            if(UserFunction.CatsitterUser(AuthorizationPage.user))
            {
                btnRespond.Visibility = Visibility.Visible;
            }

            this.DataContext = application;
        }
        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatsitterRegistPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btnRespond_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUserApplication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
