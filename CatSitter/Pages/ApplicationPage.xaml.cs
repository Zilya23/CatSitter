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
    /// Логика взаимодействия для ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        public static List<Applictioon> applicationList { get; set; }
        public ApplicationPage()
        {
            InitializeComponent();
            applicationList = ApplicationFunction.GetApplications();
            this.DataContext = this;

        }

        private void lvApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CatsitterRegistPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
