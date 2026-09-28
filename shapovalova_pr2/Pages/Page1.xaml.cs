using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
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


namespace shapovalova_pr2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (!int.TryParse(txtInput.Text, out n) || n < 1 || n > 100)
            {
                MessageBox.Show("Введите натуральное n от 1 до 100.");
                return;
            }

            BigInteger factorial = BigInteger.One;
            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * i;
            }

            BigInteger result = 2 * factorial;
            txtResult.Text = "2 * " + n + "! = " + result;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).GoBackToMenu();
        }
    }
}
