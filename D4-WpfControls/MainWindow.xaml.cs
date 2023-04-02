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

namespace D4_WpfControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TaskProgress> items = new List<TaskProgress>();
            items.Add(new TaskProgress() { Title = "zadanie 1", Progress = 30 });
            items.Add(new TaskProgress() { Title = "zadanie 2", Progress = 50 });
            items.Add(new TaskProgress() { Title = "zadanie 3", Progress = 10 });
            items.Add(new TaskProgress() { Title = "zadanie 4", Progress = 90 });
            lbTasks.ItemsSource = items;
        }


    }

    public class TaskProgress
    {
        public string Title { get; set;}
        public int Progress { get; set;}
    }
}
