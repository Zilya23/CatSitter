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
        public static List<Application_Animal> applications = new List<Application_Animal>();
        public static List<Animal> animalss = new List<Animal>();
        public AddApplication(Applictioon applictioon = null)
        {
            InitializeComponent();
            List<City> cities = CityFunction.GetCities();
            cbCity.ItemsSource = cities;
            cbCity.DisplayMemberPath = "Name";

            var animals = AnimalFunction.GetAnimals();
            cbTypeAnimal.ItemsSource = animals;
            cbTypeAnimal.DisplayMemberPath = "Name";

            if (applictioon != null)
            {

            }
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

        private void btnUserApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserApplicationPage());
        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {
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
            if (tbName.Text.Trim().Length != 0)
            {
                constApplictioon.Name = tbName.Text.Trim();
            }
            else if (tbDescription.Text.Trim().Length != 0)
            {
                constApplictioon.Description = tbDescription.Text.Trim();
            }
            else if(dpStartDate.Text.Length != 0)
            {
                constApplictioon.StartDate = Convert.ToDateTime(dpStartDate.Text);
            }
            else if(dpEndDate.Text.Length != 0)
            {
                constApplictioon.EndDate = Convert.ToDateTime(dpEndDate.Text);
            }
            else if(tbPrice.Text.Trim().Length != 0)
            {
                constApplictioon.Price = Convert.ToDecimal(tbPrice.Text.Trim());
            }
            else if(cbCity.SelectedItem != null)
            {
                constApplictioon.IDCity = (cbCity.SelectedItem as City).ID;
            }
            else if(applications.Count != 0)
            {
                constApplictioon.IDUser = AuthorizationPage.user.ID;
                constApplictioon.Active = true;
                ApplicationFunction.AddApplication(constApplictioon);
                AnimalFunction.SaveAnimalApplicqation(applications);
                MessageBox.Show("Успешно!");
                NavigationService.Navigate(new ApplicationPage());
            }
            else
            {
                MessageBox.Show("Заполните все данные");
            }
        }

        private void btnDelAmimal_Click(object sender, RoutedEventArgs e)
        {
            if (lvAnimal.SelectedItem != null)
            {
                var IDAnimal = lvAnimal.SelectedItem as Animal;
                Application_Animal application = applications.Where(x => x.ID_Animal == IDAnimal.ID).FirstOrDefault();
                applications.Remove(application);
                animalss.Remove(IDAnimal);
            }
            UpdateAnimal();
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypeAnimal.SelectedItem != null)
            {
                Application_Animal animalApplication = new Application_Animal();
                Animal selectAnimal = cbTypeAnimal.SelectedItem as Animal;
                animalApplication.ID_Application = constApplictioon.ID;
                animalApplication.ID_Animal = selectAnimal.ID;
                var isAnimal = applications.Where(x => x.ID_Application == animalApplication.ID_Application && x.ID_Animal == animalApplication.ID_Animal).Count();
                if (isAnimal == 0)
                {
                    applications.Add(animalApplication);
                    animalss.Add(cbTypeAnimal.SelectedItem as Animal);
                }
            }
            UpdateAnimal();
        }

        public void UpdateAnimal()
        {
            lvAnimal.ItemsSource = animalss;
            lvAnimal.Items.Refresh();
        }
    }
}
