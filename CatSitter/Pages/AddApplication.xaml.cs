using Microsoft.Win32;
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
using System.IO;

namespace CatSitter.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddApplication.xaml
    /// </summary>
    public partial class AddApplication : Page
    {
        public static Applictioon constApplictioon = new Applictioon();
        public AddApplication()
        {
            InitializeComponent();
            List<City> cities = CityFunction.GetCities();
            cbCity.ItemsSource = cities;
            cbCity.DisplayMemberPath = "Name";

            var animals = AnimalFunction.GetAnimals();
            cbTypeAnimal.ItemsSource = animals;
            cbTypeAnimal.DisplayMemberPath = "Name";
        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new ApplicationPage());
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new CatsitterRegistPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btnUserApplication_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new UserApplicationPage());
        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new RespondPage());
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                constApplictioon.Photo = File.ReadAllBytes(openFile.FileName);
                imgPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            constApplictioon.Name = tbName.Text.Trim();
            constApplictioon.Description = tbDescription.Text.Trim();
            constApplictioon.StartDate = Convert.ToDateTime(dpStartDate.Text);
            constApplictioon.EndDate = Convert.ToDateTime(dpEndDate.Text);
            constApplictioon.Price = Convert.ToDecimal(tbPrice.Text.Trim());
            constApplictioon.IDCity = (cbCity.SelectedItem as City).ID;
            constApplictioon.IDUser = AuthorizationPage.user.ID;
            constApplictioon.Active = true;
            ApplicationFunction.AddApplication(constApplictioon);
            MessageBox.Show("Успешно!");
            bd_connection.connection = new CatSitterEntities1();
            NavigationService.Navigate(new ApplicationPage());
        }

        private void btnDelAmimal_Click(object sender, RoutedEventArgs e)
        {
            if (lvAnimal.SelectedItem != null)
            {
                int IDAnimal = (int)(lvAnimal.SelectedItem as User_Animal).IDAnimal;
                AnimalFunction.DeleteApplicationAnimal(constApplictioon, lvAnimal.SelectedItem as Application_Animal);
                UpdateAnimal();
            }
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypeAnimal.SelectedItem != null)
            {
                Application_Animal animalApplication = new Application_Animal();
                Animal selectAnimal = cbTypeAnimal.SelectedItem as Animal;
                animalApplication.ID_Application = constApplictioon.ID;
                animalApplication.ID_Animal = selectAnimal.ID;
                var isAnimal = AnimalFunction.AnimaleUniqApp((int)animalApplication.ID_Application, (int)animalApplication.ID_Animal);
                if (isAnimal == 0)
                {
                    AnimalFunction.SaveAnimalApplication(animalApplication);
                }
                UpdateAnimal();
            }
        }

        public void UpdateAnimal()
        {
            lvAnimal.ItemsSource = constApplictioon.Application_Animal;
            lvAnimal.Items.Refresh();
        }
    }
}
