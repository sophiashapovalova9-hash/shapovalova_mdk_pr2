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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text;

            if (input == null || input.Trim() == "")
            {
                MessageBox.Show("Введите строку.");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!(char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Только русские слова и пробелы.");
                    return;
                }
            }

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                if (i > 0)
                {
                    sb.Append(" ");
                }
            }

            txtResult.Text = sb.ToString();
        }

        private void btnBack_Click(object sender, object e)
        {
            ((MainWindow)Window.GetWindow(this)).GoBackToMenu();
        }
    }
}
