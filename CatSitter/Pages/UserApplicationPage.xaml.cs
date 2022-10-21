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
    /// Логика взаимодействия для UserApplicationPage.xaml
    /// </summary>
    public partial class UserApplicationPage : Page
    {
        public static List<Applictioon> listApplication { get; set; }
        public UserApplicationPage()
        {
            InitializeComponent();
            listApplication = ApplicationFunction.GetApplictioonsUser(AuthorizationPage.user.ID);

            this.DataContext = this;
        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatsitterRegistPage());
        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RespondPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void lvUserApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectApplication = lvUserApplication.SelectedItem as Applictioon;
            NavigationService.Navigate(new ViewApplicationPage(selectApplication));
        }
    }
}
