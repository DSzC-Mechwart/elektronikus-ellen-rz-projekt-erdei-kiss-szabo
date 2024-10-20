using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SzemelyiAdatMegjelenites.xaml
    /// </summary>
    public partial class SzemelyiAdatMegjelenites : Window
    {
        List<szAdat> szAdatok = [];
        public SzemelyiAdatMegjelenites()
        {
            InitializeComponent();
            szAdatMegjel_Feltoltes();
            szAdatMegjelDataGrid.ItemsSource = szAdatok;
        }

        private void szAdatMegjel_Feltoltes()
        {
            szAdatok = [];
            foreach (var item in File.ReadAllLines("SzemelyiAdatok.csv", Encoding.UTF8).Skip(1))
            {
                string[] sor = item.Split(';');
                string Nev = sor[0];
                string SzuletesiHely = sor[1];
                DateOnly SzuletesiIdo = DateOnly.FromDateTime(Convert.ToDateTime(sor[2]));
                string AnyjaNeve = sor[3];
                string Lakcim = sor[4];
                DateOnly Beiratkozas = DateOnly.FromDateTime(Convert.ToDateTime(sor[5]));
                string Szak = sor[6];
                string Osztaly = sor[7];
                bool Kollegista = (sor[8] == "Igen") ? true : false;
                string Kollegium = sor[9];
                string TorzslapSzam = sor[10];
                szAdat Adat = new(Nev, SzuletesiHely, SzuletesiIdo, AnyjaNeve, Lakcim, Beiratkozas, Szak, Osztaly, Kollegista, Kollegium, TorzslapSzam);
                szAdatok.Add(Adat);
            }
        }

        private void szAdatMegjelDataGrid_Changed(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
