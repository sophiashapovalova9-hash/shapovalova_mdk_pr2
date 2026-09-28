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

namespace shapovalova_pr2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string[] parts = txtInput.Text.Split(new char[] { ' ' },
                                                  StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                MessageBox.Show("Введите массив чисел через пробел.");
                return;
            }

            int[] a = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out a[i]))
                {
                    MessageBox.Show("Элемент «" + parts[i] + "» не целое число.");
                    return;
                }
            }

            int b;
            if (!int.TryParse(txtB.Text, out b))
            {
                MessageBox.Show("Введите число b.");
                return;
            }

            int[] result = new int[a.Length];
            int k = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= b)
                {
                    result[k] = a[i];
                    k++;
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b)
                {
                    result[k] = a[i];
                    k++;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i]);
                if (i < result.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            txtResult.Text = sb.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).GoBackToMenu();
        }
    }
}
