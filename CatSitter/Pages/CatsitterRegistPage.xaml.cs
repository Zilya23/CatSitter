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
        //List<User_Animal> user_Animals = new List<User_Animal>();
        public CatsitterRegistPage()
        {
            InitializeComponent();
            housings = HousingFunction.GetHousings();
            cbHousing.ItemsSource = housings;
            cbHousing.DisplayMemberPath = "Name";

            animals = AnimalFunction.GetAnimals();
            cbTypeAnimal.ItemsSource = animals;
            cbTypeAnimal.DisplayMemberPath = "Name";

            this.DataContext = this;
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            bd_connection.connection = new CatSitterEntities();
            AuthorizationPage.user = null;
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
                    //AuthorizationPage.user.User_Animal.Add(new User_Animal() { User = AuthorizationPage.user, Animal = cbTypeAnimal.SelectedItem as Animal });
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
                //AnimalFunction.DeleteUserAnimal(IDUser, IDAnimal);
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

        }
    }
}
