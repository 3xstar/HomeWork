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

namespace expense_accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double day1 = Convert.ToDouble(MondayTextBox.Text);
                double day2 = Convert.ToDouble(TuesdayTextBox.Text);
                double day3 = Convert.ToDouble(WednesdayTextBox.Text);
                double day4 = Convert.ToDouble(ThursdayTextBox.Text);
                double day5 = Convert.ToDouble(FridayTextBox.Text);
                double day6 = Convert.ToDouble(SaturdayTextBox.Text);
                double day7 = Convert.ToDouble(SundayTextBox.Text);
                TotalAmountTextBox.Text = (day1 + day2 + day3 + day4 + day5 + day6 + day7).ToString();
                AverageConsumptionTextBox.Text = ((day1 + day2 + day3 + day4 + day5 + day6 + day7) / 7).ToString();
                HighestDailyExpenseTextBox.Text = new double[] { day1, day2, day3, day4, day5, day6, day7 }.Max().ToString();
            }
            catch
            {
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TotalAmountTextBox.Text = "0";
            AverageConsumptionTextBox.Text = "0";
            HighestDailyExpenseTextBox.Text = "0";
        }
    }
}
