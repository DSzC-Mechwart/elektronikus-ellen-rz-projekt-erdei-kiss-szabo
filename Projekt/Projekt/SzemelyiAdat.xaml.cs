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
    /// Interaction logic for SzemelyiAdat.xaml
    /// </summary>
    public partial class SzemelyiAdat : Window
    {
        public SzemelyiAdat()
        {
            InitializeComponent();
            szuletesiIdo.SelectedDate = DateTime.Now;
            beiratkozas.SelectedDate = DateTime.Now;
        }
        private void visszaGomb_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void kollegista_Changed(object sender, RoutedEventArgs e)
        {
            kollegium.Visibility = (kollegium.Visibility==Visibility.Hidden) ? Visibility.Visible : Visibility.Hidden;
            kollegiumLabel.Visibility = (kollegiumLabel.Visibility==Visibility.Hidden) ? Visibility.Visible : Visibility.Hidden;
        }

        private void leadasGomb_Click(object sender, RoutedEventArgs e)
        {
            string Nev = nev.Text;
            string SzuletesiHely = szuletesiHely.Text;
            DateOnly SzuletesiIdo = DateOnly.FromDateTime(szuletesiIdo.SelectedDate!.Value);
        }
    }
}
