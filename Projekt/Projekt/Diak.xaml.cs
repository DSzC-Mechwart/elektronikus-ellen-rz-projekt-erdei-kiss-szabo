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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new DiakPage();
            diakF.IsEnabled = false;
            adminF.IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminPage();
            adminF.IsEnabled = false;
            diakF.IsEnabled = false;
        }
    }
}
