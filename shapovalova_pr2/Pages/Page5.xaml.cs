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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int rows;
            int cols;
            if (!int.TryParse(txtRows.Text, out rows) || rows <= 0 ||
                !int.TryParse(txtCols.Text, out cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректные M и N (> 0).");
                return;
            }

            int[,] matrix = new int[rows, cols];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rnd.Next(-10, 11);
                }
            }

            int[] flat = new int[rows * cols];
            int k = 0;
            int min = matrix[0, 0];
            int max = matrix[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flat[k] = matrix[i, j];
                    k++;
                    if (matrix[i, j] < min) min = matrix[i, j];
                    if (matrix[i, j] > max) max = matrix[i, j];
                }
            }

            int[] asc = new int[flat.Length];
            for (int i = 0; i < flat.Length; i++)
            {
                asc[i] = flat[i];
            }
            Array.Sort(asc);

            int[] desc = new int[flat.Length];
            for (int i = 0; i < flat.Length; i++)
            {
                desc[i] = flat[i];
            }
            Array.Sort(desc);
            Array.Reverse(desc);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Исходный:");
            sb.Append(MatrixToString(matrix, rows, cols));
            sb.AppendLine("Минимум: " + min + ", Максимум: " + max);
            sb.AppendLine();
            sb.AppendLine("По возрастанию:");
            sb.Append(FlatToString(asc, rows, cols));
            sb.AppendLine("По убыванию:");
            sb.Append(FlatToString(desc, rows, cols));

            txtResult.Text = sb.ToString();
        }
        private string MatrixToString(int[,] m, int rows, int cols)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(m[i, j].ToString().PadLeft(4));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private string FlatToString(int[] flat, int rows, int cols)
        {
            StringBuilder sb = new StringBuilder();
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(flat[k].ToString().PadLeft(4));
                    k++;
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).GoBackToMenu();
        }
    }
}
