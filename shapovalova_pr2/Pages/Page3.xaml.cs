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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).GoBackToMenu();
        }

        private void btnCalculate_Click(object sender, object e)
        {
            string[] parts = txtInput.Text
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                MessageBox.Show("Введите числа через пробел.");
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

            int bestStart = 0, bestLen = 1;
            int curStart = 0, curLen = 1;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] != 0 && a[i] % a[i - 1] == 0)
                {
                    curLen++;
                }
                else
                {
                    if (curLen > bestLen)
                    {
                        bestLen = curLen;
                        bestStart = curStart;
                    }
                    curStart = i;
                    curLen = 1;
                }
            }
            if (curLen > bestLen)
            {
                bestLen = curLen;
                bestStart = curStart;
            }

            var sub = a.Skip(bestStart).Take(bestLen);
            txtResult.Text = "Длина: " + bestLen + Environment.NewLine +
                             "Элементы: " + string.Join(" ", sub);
        }
    }
}
