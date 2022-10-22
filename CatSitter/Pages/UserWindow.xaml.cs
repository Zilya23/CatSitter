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
using System.Windows.Shapes;
using Core.DataBase;
using Core.Functions;

namespace CatSitter.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        User selectUser { get; set; } 
        public UserWindow(User user)
        {
            InitializeComponent();
            selectUser = user;

            if(user.ThereAnimal == true)
            {
                tbAnimal.Text = "Eсть";
            }
            else
            {
                tbAnimal.Text = "Нет";
            }

            if (user.ThereChildren == true)
            {
                tbChildren.Text = "Eсть";
            }
            else
            {
                tbChildren.Text = "Нет";
            }

            this.DataContext = selectUser;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnNoAccept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
