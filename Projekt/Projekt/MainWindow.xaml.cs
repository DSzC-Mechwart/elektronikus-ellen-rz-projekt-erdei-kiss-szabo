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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            diakbej.IsEnabled = false;
            adminbej.IsEnabled = false;
        }

        private void diakbe(object sender, RoutedEventArgs e)
        {
            new Diak().Show();
            Close();
        }

        private void adminbe(object sender, RoutedEventArgs e)
        {
            new Admin().Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            diakbej.IsEnabled = true;
            adminbej.IsEnabled = true;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            diakbej.IsEnabled = true;
            adminbej.IsEnabled = true;
        }
    }
}