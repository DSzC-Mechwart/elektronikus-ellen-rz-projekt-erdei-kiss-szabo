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
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for SzemelyiAdat.xaml
    /// </summary>
    public partial class SzemelyiAdat : Window
    {
        bool Kollegista = false;
        List<szAdat> KorabbiAdatok;
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
            if (kollegium.Visibility==Visibility.Hidden)
            {
                kollegium.Visibility=Visibility.Visible;
                Kollegista = true;
            }
            else
            {
                kollegium.Visibility = Visibility.Hidden;
                Kollegista = false;
            }
        }

        private void KorabbiData()
        {
            KorabbiAdatok = [];
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
                KorabbiAdatok.Add(Adat);
            }
        }

        private void leadasGomb_Click(object sender, RoutedEventArgs e)
        {
            KorabbiData();
            string Nev = nev.Text;
            string SzuletesiHely = szuletesiHely.Text;
            DateOnly SzuletesiIdo = DateOnly.FromDateTime(szuletesiIdo.SelectedDate!.Value);
            string AnyjaNeve = anyjaNeve.Text;
            string Lakcim = lakcim.Text;
            DateOnly Beiratkozas = DateOnly.FromDateTime(beiratkozas.SelectedDate!.Value);
            string Szak = szak.Text;
            string Osztaly = osztaly.Text;
            string Kollegium = (Kollegista) ? kollegium.Text : "Nincs";
            int SorSzam = Convert.ToInt32(File.ReadLines("SzemelyiAdatok.csv").First());
            string TorzslapSzam = $"{SorSzam}/{Beiratkozas.Year}";
            szAdat Adat = new(Nev, SzuletesiHely, SzuletesiIdo, AnyjaNeve, Lakcim, Beiratkozas, Szak, Osztaly, Kollegista, Kollegium, TorzslapSzam);
            using (StreamWriter writer = new StreamWriter("SzemelyiAdatok.csv"))
            {
                writer.WriteLine($"{SorSzam+1}");
                foreach(var item in KorabbiAdatok)
                {
                    writer.WriteLine($"{item.Nev};{item.SzuletesiHely};{item.SzuletesiIdo};{item.AnyjaNeve};{item.Lakcim};{item.BeiratkozasIdeje};{item.Szak};{item.Osztaly};{((item.Kollegista) ? "Igen" : "Nem")};{item.Kollegium};{item.Torzslapszam}");
                }
                writer.WriteLine($"{Adat.Nev};{Adat.SzuletesiHely};{Adat.SzuletesiIdo};{Adat.AnyjaNeve};{Adat.Lakcim};{Adat.BeiratkozasIdeje};{Adat.Szak};{Adat.Osztaly};{((Adat.Kollegista) ? "Igen" : "Nem")};{Adat.Kollegium};{Adat.Torzslapszam}"); 
            }
        }
    }
}
