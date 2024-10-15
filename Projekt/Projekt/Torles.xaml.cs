using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Torles.xaml
    /// </summary>
    public partial class Torles : Window
    {
        List<TTargy> Tantargyak = [];
        public Torles()
        {
            InitializeComponent();
            ListaFeltotlese();
            TantargyDatagrid.ItemsSource = Tantargyak;
        }

        private void ListaFeltotlese()
        {
            foreach (var sor in File.ReadAllLines("tantargyak.csv"))
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
}
