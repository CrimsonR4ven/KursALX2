using System;
using System.Collections.Generic;
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

namespace WpfDataBinding
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        User usr = new User() { FirstName = "Jan", LastName = "Kowal", Pesel = "12345678901" };
        public UserDetails()
        {
            InitializeComponent();
            var usr = new User() { FirstName = "Jan", LastName = "Kowal", Pesel = "12345678901" };
            this.DataContext = usr;
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                usr.FirstName = "hehehe";
                usr.LastName = "działa";
                usr.Pesel = "094309345043";
            });
        }
    }
}
