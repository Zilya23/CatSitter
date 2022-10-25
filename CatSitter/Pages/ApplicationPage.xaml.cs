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

            List<Item> priceItem = new List<Item>();
            priceItem.Add(new Item() { ID = 0, Name = "Все" });
            priceItem.Add(new Item() { ID = 1, Name = "По возрастанию"});
            priceItem.Add(new Item() { ID = 2, Name = "По убыванию" });
            cbPrice.ItemsSource = priceItem;
            cbPrice.DisplayMemberPath = "Name";

            List<Item> dateItem = new List<Item>();
            dateItem.Add(new Item() { ID = 0, Name = "Все" });
            dateItem.Add(new Item() { ID = 1, Name = "По возрастанию" });
            dateItem.Add(new Item() { ID = 2, Name = "По убыванию" });
            cbDate.ItemsSource = dateItem;
            cbDate.DisplayMemberPath = "Name";

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
            bd_connection.connection = new CatSitterEntities();
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
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

        private void cbPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            List<Applictioon> listFilter = ApplicationFunction.GetApplications();

            if (cbCity.SelectedIndex > 0)
            {
                var city = cbCity.SelectedItem as City;
                listFilter = listFilter.Where(a => a.IDCity == city.ID).ToList();
            }
            else if (cbCity.SelectedIndex == 0)
            {
                listFilter = ApplicationFunction.GetApplications();
                lvApplication.ItemsSource = listFilter;
            }

            if(cbPrice.SelectedIndex > 0)
            {
                var price = cbPrice.SelectedItem as Item;
                if(price.ID == 1)
                {
                    listFilter = listFilter.OrderBy(c => c.Price).ToList();
                }
                else if(price.ID == 2)
                {
                    listFilter = listFilter.OrderByDescending(c => c.Price).ToList();
                }
            }


            if(cbDate.SelectedIndex > 0)
            {
                var dateApplication = cbDate.SelectedItem as Item;
                if(dateApplication.ID == 1)
                {
                    listFilter = listFilter.OrderBy(c => c.StartDate).ToList();
                }
                else if(dateApplication.ID == 2)
                {
                    listFilter = listFilter.OrderByDescending(c => c.StartDate).ToList();
                }
            }

            if (listFilter.Count == 0)
            {
                tbEmpty.Visibility = Visibility;
            }
            else
            {
                tbEmpty.Visibility = Visibility.Hidden;
            }

            lvApplication.ItemsSource = listFilter;
        }

        public class Item
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private void cbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
