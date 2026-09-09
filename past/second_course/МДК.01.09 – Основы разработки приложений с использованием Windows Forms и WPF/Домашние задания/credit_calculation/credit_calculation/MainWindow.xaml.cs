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

namespace credit_calculation
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
            string loanamount = LoanAmount.Text;
            string monthpayment = MonthPayment.Text;

            if (float.TryParse(loanamount, out float loanamountf) && float.TryParse(monthpayment, out float monthpaymentf))
            {
                float result_in_months = loanamountf / monthpaymentf;
                InMonths.Content = result_in_months.ToString();

                float result_in_years = result_in_months / 12;
                InYears.Content = result_in_years.ToString();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
