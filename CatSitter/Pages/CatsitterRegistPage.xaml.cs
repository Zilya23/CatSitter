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
    /// Логика взаимодействия для CatsitterRegistPage.xaml
    /// </summary>
    public partial class CatsitterRegistPage : Page
    {
        List<Housing> housings { get; set; }
        List<Animal> animals { get; set; }
        public CatsitterRegistPage()
        {
            InitializeComponent();
            housings = HousingFunction.GetHousings();
            cbHousing.ItemsSource = housings;
            cbHousing.DisplayMemberPath = "Name";

            animals = AnimalFunction.GetAnimals();
            cbTypeAnimal.ItemsSource = animals;
            cbTypeAnimal.DisplayMemberPath = "Name";

            if (AuthorizationPage.user.CaringExperience != null)
            {
                cbHousing.SelectedItem = AuthorizationPage.user.Housing;
                lvAnimal.ItemsSource = AuthorizationPage.user.User_Animal;
                lvAnimal.Items.Refresh();

                cbAnimal.IsChecked = AuthorizationPage.user.ThereAnimal;
                cbChildren.IsChecked = AuthorizationPage.user.ThereChildren;
                tbAnimalCount.Text = AuthorizationPage.user.NumberAnimalReceive.ToString();
                tbYears.Text = AuthorizationPage.user.CaringExperience.ToString();
            }

            this.DataContext = this;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities();
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            int years = Convert.ToInt32(tbYears.Text);
            if (years != 0)
            {
                tbYears.Text = (years - 1).ToString();
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            int years = Convert.ToInt32(tbYears.Text);
            tbYears.Text = (years + 1).ToString();
        }

        private void btnMinusAnimal_Click(object sender, RoutedEventArgs e)
        {
            int countAnimal = Convert.ToInt32(tbAnimalCount.Text);
            if (countAnimal != 0)
            {
                tbAnimalCount.Text = (countAnimal - 1).ToString();
            }
        }

        private void btnPlusAnimal_Click(object sender, RoutedEventArgs e)
        {
            int countAnimal = Convert.ToInt32(tbAnimalCount.Text);
            tbAnimalCount.Text = (countAnimal + 1).ToString();
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypeAnimal.SelectedItem != null)
            {
                User_Animal animalUser = new User_Animal();
                Animal selectAnimal = cbTypeAnimal.SelectedItem as Animal;
                animalUser.IDUser = AuthorizationPage.user.ID;
                animalUser.IDAnimal = selectAnimal.ID;
                var isAnimal = AnimalFunction.AnimaleUniq((int)animalUser.IDUser, (int)animalUser.IDAnimal);
                if (isAnimal == 0)
                {
                    AnimalFunction.SaveAnimalUser(animalUser);
                }
                UpdateAnimal();
            }
        }

        private void btn_del_Animal_Click(object sender, RoutedEventArgs e)
        {
            if (lvAnimal.SelectedItem != null)
            {
                int IDUser = AuthorizationPage.user.ID;
                int IDAnimal = (int)(lvAnimal.SelectedItem as User_Animal).IDAnimal;
                AnimalFunction.DeleteUserAnimal(AuthorizationPage.user, lvAnimal.SelectedItem as User_Animal);
                UpdateAnimal();
            }
        }

        public void UpdateAnimal()
        {
            lvAnimal.ItemsSource = AuthorizationPage.user.User_Animal;
            lvAnimal.Items.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User user = AuthorizationPage.user;
            user.CaringExperience = Convert.ToInt32(tbYears.Text);
            if(cbHousing.SelectedItem != null)
            {
                user.IDHousing = (cbHousing.SelectedItem as Housing).ID;
            }
            user.ThereAnimal = cbAnimal.IsChecked;
            user.ThereChildren = cbChildren.IsChecked;
            user.NumberAnimalReceive = Convert.ToInt32(tbAnimalCount.Text);
            bd_connection.connection.SaveChanges();
            bd_connection.connection = new CatSitterEntities();
            NavigationService.Navigate(new ApplicationPage());
        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities();
            NavigationService.Navigate(new ApplicationPage());
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
