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
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for WpfResources.xaml
    /// </summary>
    public partial class WpfResources : Window
    {
        public WpfResources()
        {
            InitializeComponent();
            Application.Current.Resources["DynamicColorBrush"] = Brushes.Red;
        }
        private bool isRed = true; 
        private bool isGreen = false; 
        private bool isBlue = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            var s1 = s.ToLower();
            if (isRed)
            {
                Application.Current.Resources["DynamicColorBrush"] = Brushes.Green;
                isRed   = !isRed;
                isGreen = !isGreen;
            }
            else if (isGreen)
            {
                Application.Current.Resources["DynamicColorBrush"] = Brushes.Blue;
                isGreen = !isGreen;
                isBlue  = !isBlue;
            }
            else
            {
                Application.Current.Resources["DynamicColorBrush"] = Brushes.Red;
                isBlue = !isBlue;
                isRed  = !isRed;
            }
        }
    }
}
