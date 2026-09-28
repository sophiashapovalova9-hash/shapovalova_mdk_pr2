using shapovalova_pr2.Pages;
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

namespace shapovalova_pr2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ShowTask(Page page)
        {
            MenuPanel.Visibility = Visibility.Collapsed;
            FrmMain.Visibility = Visibility.Visible;
            FrmMain.Navigate(page);
        }

        private void btnTask1_Click(object sender, RoutedEventArgs e)
        {
            ShowTask(new Page1());
        }

        private void btnTask2_Click(object sender, RoutedEventArgs e)
        {
            ShowTask(new Page2());
        }

        private void btnTask3_Click(object sender, RoutedEventArgs e)
        {
            ShowTask(new Page3());
        }
        private void btnTask4_Click(object sender, RoutedEventArgs e)
        {
            ShowTask(new Page4());
        }
        private void btnTask5_Click(object sender, RoutedEventArgs e)
        {
            ShowTask(new Page5());
        }
        public void GoBackToMenu()
        {
            FrmMain.Visibility = Visibility.Collapsed;
            MenuPanel.Visibility = Visibility.Visible;
        }
    }
}
