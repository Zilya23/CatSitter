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
    /// Логика взаимодействия для ViewApplicationPage.xaml
    /// </summary>
    public partial class ViewApplicationPage : Page
    {
        public static Applictioon application {get; set;}
        public ViewApplicationPage(Applictioon applictioon, Visibility visibility = Visibility.Hidden, Visibility visibilityUser = Visibility.Hidden)
        {
            InitializeComponent();
            application = applictioon;

            tbDate.Text = " с " + application.StartDate.ToString().Split(' ')[0] + " по " + application.EndDate.ToString().Split(' ')[0];

            if(UserFunction.CatsitterUser(AuthorizationPage.user))
            {
                btnRespond.Visibility = Visibility.Visible;
            }

            if (!ApplicationFunction.UniqApplicationUser(AuthorizationPage.user.ID, application.ID))
            {
                btnRespond.Visibility = Visibility.Hidden;
            }

            if(ApplicationFunction.IsYou(AuthorizationPage.user, applictioon))
            {
                btnRespond.Visibility = Visibility.Hidden;
            }

            if(visibilityUser == Visibility.Visible)
            {
                var catsitterList = ApplicationFunction.GetRespond(application.ID);
                if (catsitterList.Count != 0)
                {
                    spCatsitter.Visibility = Visibility.Visible;
                    lvCatsitter.ItemsSource = catsitterList;
                }
            }

            if(ApplicationFunction.IsYou(AuthorizationPage.user, applictioon))
            {
                btnDelete.Visibility = Visibility.Visible;
            }

            tbtrueCatsitter.Visibility = visibility;
            cbTrueCatsitter.Visibility = visibility;
            if(visibility == Visibility.Visible)
            {
                cbTrueCatsitter.IsEnabled = true;
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
            User_Application userApplication = new User_Application();
            userApplication.IDUser = AuthorizationPage.user.ID;
            userApplication.IDApplication = application.ID;
            if (ApplicationFunction.UniqApplicationUser((int)userApplication.IDUser, (int)userApplication.IDApplication))
            {
                ApplicationFunction.SaveRespond(userApplication);
                NavigationService.Navigate(new ApplicationPage());
            }
            else
            {
                MessageBox.Show("Вы уже откликнулись на эту заявку");
            }
        }

        private void btnUserRespond_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RespondPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ApplicationFunction.DeleteApplication(application);
            NavigationService.Navigate(new UserApplicationPage());
        }

        private void btnRedact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddApplication(application));
        }

        private void btnSelectCatsitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvCatsitter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvCatsitter.SelectedItem != null)
            {
                var selectCatsitter = (lvCatsitter.SelectedItem as User_Application).User;
                UserWindow userWindow = new UserWindow(selectCatsitter);
                userWindow.ShowDialog();
            }
        }
    }
}
