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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.DataBase;
using Core.Functions;

namespace CatSitter.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        public static List<Applictioon> applicationList { get; set; }
        public ApplicationPage()
        {
            InitializeComponent();
            applicationList = ApplicationFunction.GetApplications();

            List<City> cities = CityFunction.GetCities();
            cities.Insert(0, new City() { ID = -1, Name = "Все" });
            cbCity.ItemsSource = cities;
            cbCity.DisplayMemberPath = "Name";

            this.DataContext = this;
        }

        private void lvApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvApplication.SelectedItem != null)
            {
                Applictioon applictioon = lvApplication.SelectedItem as Applictioon;
                NavigationService.Navigate(new ViewApplicationPage(applictioon));
            }
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatsitterRegistPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbCity.SelectedIndex > 0)
            {
                var city = cbCity.SelectedItem as City;
                var listsity = bd_connection.connection.Applictioon.Where(a => a.IDCity == city.ID).ToList();
                lvApplication.ItemsSource = listsity;
                if (listsity.Count == 0)
                {
                    tbEmpty.Visibility = Visibility;
                }
                else
                {
                    tbEmpty.Visibility = Visibility.Hidden;
                }
            }
            else if(cbCity.SelectedIndex == 0)
            {
                var listsity = ApplicationFunction.GetApplications();
                lvApplication.ItemsSource = listsity;
                if (listsity.Count == 0)
                {
                    tbEmpty.Visibility = Visibility;
                }
                else
                {
                    tbEmpty.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddApplication());
        }

        private void btnUserApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserApplicationPage());
        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RespondPage());
        }
    }
}
