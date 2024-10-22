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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    public class Jegy
    {
        public string Tantargy { get; set; }
        public int ÉrdemJegy { get; set; }
        public string Tema { get; set; }
        public string SzamonkeresTipusa { get; set; }
    }

    public partial class DiakPage : Page
    {
        private string bejelentkezettDiak = "Kis Pista";

        private Dictionary<string, Dictionary<string, List<int>>> diakokJegyei;

        public DiakPage()
        {
            InitializeComponent();

            diakokJegyei = new Dictionary<string, Dictionary<string, List<int>>>
            {
                { "Geri", new Dictionary<string, List<int>> { { "Történelem", new List<int> { 4, 2 } }, { "Matematika", new List<int> { 3, 5 } } } },
                { "Anna", new Dictionary<string, List<int>> { { "Ének", new List<int> { 1, 1 } }, { "Tánc", new List<int> { 2, 4 } } } },
                { "Petra", new Dictionary<string, List<int>> { { "Szoftver tesztelés", new List<int> { 3, 2 } }, { "Programozás", new List<int> { 4, 4 } } } },
                { "Kis Pista", new Dictionary<string, List<int>> { { "Fizika", new List<int> { 5, 4 } }, { "Kémia", new List<int> { 3, 2 } } } }
            };

        }
        private void JegyHozzaadasa(object sender, RoutedEventArgs e)
        {
            string selectedTargy = targyComboBox.SelectedItem?.ToString();
            int selectedJegy = int.Parse((jegyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());

            if (diakokJegyei.ContainsKey(bejelentkezettDiak) && diakokJegyei[bejelentkezettDiak].ContainsKey(selectedTargy))
            {
                diakokJegyei[bejelentkezettDiak][selectedTargy][0] += selectedJegy;
            }

        }
    }
}
