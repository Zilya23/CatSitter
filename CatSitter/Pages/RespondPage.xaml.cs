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
    /// Логика взаимодействия для RespondPage.xaml
    /// </summary>
    public partial class RespondPage : Page
    {
        public static List<User_Application> listRespond { get; set; }
        public RespondPage()
        {
            InitializeComponent();
            listRespond = ApplicationFunction.GetUserRespond(AuthorizationPage.user.ID);

            List<string> statusRespond = new List<string>(){"Все", "Одобрено хозяином", "Утверждено", "Отказано" };
            cbStatus.ItemsSource = statusRespond;

            this.DataContext = this;
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatsitterRegistPage());
        }

        private void btnUserApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserApplicationPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }

        private void lvRespond_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvRespond.SelectedItem != null)
            {
                var selectApplication = (lvRespond.SelectedItem as User_Application).Applictioon;
                NavigationService.Navigate(new ViewApplicationPage(selectApplication, Visibility.Visible));
            }
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            List<User_Application> user_Applications = new List<User_Application>();

            if(cbStatus.SelectedItem != null)
            {
                if(cbStatus.SelectedIndex == 0)
                {
                    user_Applications = listRespond;
                }
                else if(cbStatus.SelectedIndex == 1)
                {
                    user_Applications = listRespond.Where(x => x.UserRespond == true && x.ApplicationRespond == null).ToList();
                }
                else if(cbStatus.SelectedIndex == 2)
                {
                    user_Applications = listRespond.Where(x => x.UserRespond == true && x.ApplicationRespond == true).ToList();
                }
                else if(cbStatus.SelectedIndex == 3)
                {
                    user_Applications = listRespond.Where(x => x.UserRespond == false || x.ApplicationRespond == false).ToList();
                }
            }

            lvRespond.ItemsSource = user_Applications;
        }
    }
}
