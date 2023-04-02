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
    /// Interaction logic for ListViewExample.xaml
    /// </summary>
    public partial class ListViewExample : Window
    {
        public ListViewExample()
        {
            InitializeComponent();
            List<User> items = new List<User>()
            {
                new User(){Name="Jan Kowalski", Age=45},
                new User(){Name="Janina Kowalska", Age=65},
                new User(){Name="Michał Pawlak", Age=23},
                new User(){Name="Paweł Janke", Age=11}
            };
            lvUsers.ItemsSource = items;

            CollectionView view = CollectionViewSource.GetDefaultView(lvUsers.ItemsSource) as CollectionView;
            view.Filter = ValidateUser;
        }

        private bool ValidateUser(object obj)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }

            return ((obj as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) != -1);
        }
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
