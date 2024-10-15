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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for Diak.xaml
    /// </summary>
    public partial class Diak : Window
    {
        public Diak()
        {
            InitializeComponent();
            Main.Content = new DiakPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminPage();
            adminF.IsEnabled = false;
        }

        private void kilepes(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
