using System.IO;
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
            string enteredName = neve.Text;
            string enteredPassword = jelszava.Password;

            bool loginSuccess = false;
            foreach (var item in File.ReadAllLines("SzemelyiAdatok.csv", Encoding.UTF8).Skip(1))
            {
                string[] sor = item.Split(';');
                string nev = sor[0];
                string hely = sor[1];

                if (enteredName == nev && enteredPassword == hely)
                {
                    loginSuccess = true;
                    break;
                }
            }

            if (loginSuccess)
            {
                new Diak().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Hibás név vagy jelszó!");
            }
        }

        private void adminbe(object sender, RoutedEventArgs e)
        {
            new Admin().Show();
            adminbej.IsEnabled = false;
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            diakbej.IsEnabled = !string.IsNullOrWhiteSpace(neve.Text) && !string.IsNullOrWhiteSpace(jelszava.Password);
            string adminnev = neve.Text;
            string adminjelszo = jelszava.Password;
            if (adminnev == "admin" && adminjelszo == "admin") 
            {
                adminbej.IsEnabled = true;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            diakbej.IsEnabled = !string.IsNullOrWhiteSpace(neve.Text) && !string.IsNullOrWhiteSpace(jelszava.Password);
            string adminnev = neve.Text;
            string diaknev = neve.Text;
            string adminjelszo = jelszava.Password;
            string diakjelszo = jelszava.Password;
            if (adminnev == "admin" && adminjelszo == "admin")
            {
                adminbej.IsEnabled = true;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            diakbej.IsEnabled = true;
            string adminnev = neve.Text;
            string diaknev = neve.Text;
            string adminjelszo = jelszava.Password;
            string diakjelszo = jelszava.Password;
            if (adminnev== "admin" && adminjelszo == "admin")
            {
                adminbej.IsEnabled = true;
            }
            if (diaknev == "" || diakjelszo == "")
                diakbej.IsEnabled = false;
        }
    }
}