using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for ButtonCultureTest.xaml
    /// </summary>
    public partial class ButtonCultureTest : Window
    {
        public ButtonCultureTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ci = (sender as Button).Tag.ToString();
            CultureInfo culture = CultureInfo.GetCultureInfo(ci);
            Thread.CurrentThread.CurrentCulture = culture;
            lblDate.Content = DateTime.Now.ToString();
            lblNumber.Content = (123456789.12d).ToString("N2");
        }
    }
}
