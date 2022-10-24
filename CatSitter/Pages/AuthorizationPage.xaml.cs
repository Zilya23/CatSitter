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
using Core.Functions;
using Core.DataBase;

namespace CatSitter.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static User user;
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = pbPassword.Password.Trim();
            user = AuthorizationFunction.Authorization(login, password);
            if(user != null)
            {
                NavigationService.Navigate(new ApplicationPage());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void tbRegist_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
