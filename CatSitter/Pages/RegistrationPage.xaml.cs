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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            List<City> cities = CityFunction.GetCities();
            cbCity.ItemsSource = cities;
            cbCity.DisplayMemberPath = "Name";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            bool canRegist = true;
            if(tbName.Text.Trim().Length != 0)
            {
                user.Name = tbName.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (tbLastName.Text.Trim().Length != 0)
            {
                user.LastName = tbLastName.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (tbPatronymic.Text.Trim().Length != 0)
            {
                user.Patronymic = tbPatronymic.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (tbTelephone.Text.Trim().Length != 0)
            {
                user.Telephone = tbTelephone.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if(tbMail.Text.Trim().Length != 0)
            {
                user.Email = tbMail.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if(dpBithDate.Text.Trim().Length != 0)
            {
                user.BirthDate = Convert.ToDateTime(dpBithDate.Text.Trim());
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (tbAddress.Text.Trim().Length != 0)
            {
                user.Address = tbAddress.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (tbMail.Text.Trim().Length != 0)
            {
                user.Email = tbMail.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if(tbLogin.Text.Trim().Length != 0)
            {
                user.Login = tbLogin.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (tbPassword.Text.Trim().Length != 0)
            {
                user.Password = tbPassword.Text.Trim();
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if (cbCity.SelectedItem != null)
            {
                user.City = cbCity.SelectedItem as City;
            }
            else
            {
                canRegist = false;
                MessageBox.Show("Заполните все поля");
            }

            if(canRegist)
            {
                user.DateRegist = DateTime.Now;
                UserFunction.Registration(user);
                NavigationService.Navigate(new AuthorizationPage());
            }
        }
    }
}
