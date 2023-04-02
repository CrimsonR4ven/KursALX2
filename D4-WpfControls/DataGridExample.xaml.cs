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

namespace D4_WpfControls
{
    /// <summary>
    /// Interaction logic for DataGridExample.xaml
    /// </summary>
    public partial class DataGridExample : Window
    {
        public DataGridExample()
        {
            InitializeComponent();
            List<UserDob> items = new List<UserDob>()
            {
                new UserDob(){Name="Jan Kowalski", ID=1, DateOfBirth = new DateTime(2354,3,3)},
                new UserDob(){Name="Janina Kowalska", ID=2, DateOfBirth = new DateTime(2076,6,7)},
                new UserDob(){Name="Michał Pawlak", ID=3, DateOfBirth = new DateTime(1854,8,9)},
                new UserDob(){Name="Paweł Janke", ID=4, DateOfBirth = new DateTime(1023,1,2)}
            };
            dgUsers.ItemsSource = items;
            dgUsersCols.ItemsSource = items;
        }
    }
    public class UserDob
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Summary
        {
            get
            {
                return $"User: {Name}, Date of birth: {DateOfBirth.ToString()}";
            }
        }
    }
}
