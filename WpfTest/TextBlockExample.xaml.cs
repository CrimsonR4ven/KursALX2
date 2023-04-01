using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TextBlockExample.xaml
    /// </summary>
    public partial class TextBlockExample : Window
    {
        public TextBlockExample()
        {
            InitializeComponent();
            textBlockFormat.Inlines.Clear();
            textBlockFormat.Inlines.Add("AAA ");
            textBlockFormat.Inlines.Add(new Run("BBB")
            { 
                FontSize = 40, 
                FontWeight = FontWeights.ExtraLight 
            });
            textBlockFormat.Inlines.Add(new Run("CCC")
            {
                FontSize = 60,
                Foreground = Brushes.Tomato,
                TextDecorations = TextDecorations.Strikethrough
            });
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
