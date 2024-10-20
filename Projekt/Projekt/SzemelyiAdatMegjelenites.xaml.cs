using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
        //double debreceniStat, kollegistaStat, bejarosStat;
        public SzemelyiAdatMegjelenites()
        {
            InitializeComponent();
            szAdatMegjel_Feltoltes();
            szAdatMegjelDataGrid.PreviewKeyDown += szAdatMegjelDataGrid_PreviewKeyDown;
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
            szAdatMegjelDataGrid.ItemsSource = szAdatok;
            statisztika();
        }

        private void statisztika()
        {
            if (szAdatok.Count>0)
            {
                debreceniStat.Content = $"Debreceni tanulók aránya: {Math.Round(((decimal)szAdatok.Count(x => x.Lakcim.Contains("Debrecen")) / (decimal)szAdatok.Count()) * 100, 2)}%";
                kollegistaStat.Content = $"Kollégista tanulók aránya: {Math.Round(((decimal)szAdatok.Count(x => x.Kollegista) / (decimal)szAdatok.Count()) * 100),2}%";
                bejarosStat.Content = $"Bejárós tanulók aránya: {Math.Round(((decimal)(szAdatok.Count() - szAdatok.Count(x => x.Lakcim.Contains("Debrecen")) - szAdatok.Count(x => x.Kollegista)) / (decimal)szAdatok.Count()) * 100),2}%";
            }
        }
        private void szAdatMegjelDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var target = sender as DataGrid;
                if (target.SelectedItem != null)
                {
                    int targetIndex = target.Items.IndexOf(target.SelectedItem);
                    if (targetIndex >= 0 && targetIndex < szAdatok.Count)
                    {
                        if (MessageBox.Show("Biztos kitörli?", "Megerősités", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
                        {
                            szAdatok.RemoveAt(targetIndex);
                            szAdatMegjelDataGrid.ItemsSource = null;
                            szAdatMegjelDataGrid.ItemsSource = szAdatok;
                            statisztika();
                            int SorSzam = Convert.ToInt32(File.ReadLines("SzemelyiAdatok.csv").First());
                            using (StreamWriter writer = new StreamWriter("SzemelyiAdatok.csv"))
                            {
                                writer.WriteLine($"{SorSzam}");
                                foreach (var item in szAdatok)
                                {
                                    writer.WriteLine($"{item.Nev};{item.SzuletesiHely};{item.SzuletesiIdo};{item.AnyjaNeve};{item.Lakcim};{item.BeiratkozasIdeje};{item.Szak};{item.Osztaly};{((item.Kollegista) ? "Igen" : "Nem")};{item.Kollegium};{item.Torzslapszam}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
