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
        public CatsitterRegistPage()
        {
            InitializeComponent();
            housings = HousingFunction.GetHousings();
            cbHousing.ItemsSource = housings;
            cbHousing.DisplayMemberPath = "Name";
        }

        private void btnCatsitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
