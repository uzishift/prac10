using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка проверки значений в массиве.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string arrayInput = ArrayInput.Text;
                string rangeInput = RangeInput.Text;

                List<double> numbers = arrayInput
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => double.Parse(n.Trim()))
                    .ToList();

                string[] rangeParts = rangeInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                double a = double.Parse(rangeParts[0]);
                double b = double.Parse(rangeParts[1]);

                bool hasValueInRange = numbers.Any(n => n >= a && n <= b);

                ResultText.Text = hasValueInRange ? "Есть элементы внутри интервала." : "Нет элементов внутри интервала.";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, убедитесь, что введены корректные числовые значения.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Кнопка вывода информации о программе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Демьяхин Роман ИСП-31\n12 вариант\nПроверить, имеется ли в одномерном массиве хотя бы один элемент, попадающий в интервал [а; b].","О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Кнопка выхода из программы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}