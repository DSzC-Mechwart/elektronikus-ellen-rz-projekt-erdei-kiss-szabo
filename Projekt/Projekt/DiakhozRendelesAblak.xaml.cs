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
    /// Interaction logic for DiakhozRendelesAblak.xaml
    /// </summary>
    public partial class DiakhozRendelesAblak : Window
    {
        List<Tanulo> Diakok = [];
        List<TTargy> Tantargyak = [];
        Tanulo valasztottTanulo;

        public DiakhozRendelesAblak()
        {
            InitializeComponent();
            DiakokListaFeltotlese();
            TanuloDataGrid.ItemsSource = Diakok;
            TantargyakListaFeltotlese();
            TantargyDataGrid.ItemsSource = Tantargyak;
        }

        private void DiakokListaFeltotlese()
        {
            foreach (var sor in File.ReadAllLines("SzemelyiAdatok.csv").Skip(1))
            {
                if (sor != "")
                {
                    string[] resz = sor.Split(';');
                    string nev = resz[0];
                    int evfolyam = int.Parse(resz[7].Split(".")[0]);
                    Tanulo tanulo = new(nev, evfolyam);
                    Diakok.Add(tanulo);
                }
            }
        }

        private void TantargyakListaFeltotlese()
        {
            foreach (var sor in File.ReadAllLines("tantargyak.csv"))
            {
                if (sor != "")
                {
                    string[] resz = sor.Split(";");
                    string nev = resz[0];
                    string[] evfolyamReszei = resz[1].Split(".");
                    int evfolyam = int.Parse(evfolyamReszei[0]);
                    string tipus = resz[2];
                    int HetiOraszam = int.Parse(resz[3]);
                    TTargy uj = new TTargy(nev, evfolyam, tipus, HetiOraszam);
                    Tantargyak.Add(uj);
                }
            }
        }

        private void TanuloDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            valasztottTanulo = e.AddedItems[0] as Tanulo;
            TantargyDataGrid.ItemsSource = SzukitettTantargyLista(valasztottTanulo);
        }

        private List<TTargy> SzukitettTantargyLista(Tanulo tanulo)
        {
            List<TTargy> szukitettLista = new();
            foreach (var item in Tantargyak)
            {
                if (item.Evfolyam == tanulo.evfolyam)
                {
                    szukitettLista.Add(item);
                }
            }
            return szukitettLista;
        }

        private void TantargyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {       
            TTargy valasztottTargy = e.AddedItems[0] as TTargy;
            MessageBox.Show($"\"Tanulóhoz rendelt tárgyak.csv\"-hez hozá lett adva: {valasztottTanulo.nev};{valasztottTargy.Nev}");
            using (StreamWriter sw = new("Tanulóhoz rendelt tárgyak.csv", true, Encoding.UTF8))
            {
                sw.WriteLine($"{valasztottTanulo.nev};{valasztottTargy.Nev}");
            }
        }
    }
}
