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
    /// Логика взаимодействия для RedactionApplicationPage.xaml
    /// </summary>
    public partial class RedactionApplicationPage : Page
    {
        public static Applictioon applictioons = new Applictioon();
        public RedactionApplicationPage(Applictioon applictioon)
        {
            InitializeComponent();
            applictioons = applictioon;
            List<Application_Animal> animals = applictioon.Application_Animal.ToList();
            cbCity.ItemsSource = CityFunction.GetCities();
            cbCity.DisplayMemberPath = "Name";

            cbTypeAnimal.ItemsSource = AnimalFunction.GetAnimals();
            cbTypeAnimal.DisplayMemberPath = "Name";

            this.DataContext = applictioons;
        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUserApplication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelAmimal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
